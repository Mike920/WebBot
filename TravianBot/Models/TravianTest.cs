using SimpleBrowser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace TravianBot.Models
{
    //[TestFixture]
    public static class Travian
    {


        private static async void SaveInfo(string str)
        {
            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("text", str)
                });
                var result = await client.PostAsync("http://travian-2.apphb.com/Home/StoreInfo", content);
                string resultContent = await result.Content.ReadAsStringAsync();
            }
        }

        private static void Sleep(int sec)
        {
            Thread.Sleep(new TimeSpan(0, 0, sec));
        }

        public static void RunTest()
        {
            Browser browser = new Browser(null, null, null);
            browser.Navigate("http://tx3.travian.pl/");
            Sleep(3);
            browser.Find("input", FindBy.Name, "name").Value = "boruke";
            browser.Find("input", FindBy.Name, "password").Value = "kamilkos";
            browser.Find("s1").Click();
            Sleep(3);
            browser.Find("a", FindBy.PartialText, "GRABIEŻ").Click();
            Sleep(3);
            HtmlResult wyslijBtn = browser.Find("button", FindBy.PartialValue, "Wyślij na grabież");
            for (int i = 0; i < wyslijBtn.Count<HtmlResult>() / 2; i++)
            {
                foreach (HtmlResult mark in browser.Find("input", FindBy.PartialId, "slot"))
                {
                    mark.Click();
                }
                Sleep(1);
                wyslijBtn.ElementAt<HtmlResult>(i).Click();
                Sleep(2);
                string info = string.Join(" ",
                    from x in browser.Find("p", FindBy.PartialText, "wysłano")
                    select x.Value);
                try
                {
                    SaveInfo(string.Concat(DateTime.Now, " ", info));
                }
                catch (Exception exception)
                {
                }
                wyslijBtn = browser.Find("button", FindBy.PartialValue, "Wyślij na grabież");
            }
        }
    }
}