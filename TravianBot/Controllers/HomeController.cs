using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using TravianBot.Models;

namespace TravianBot.Controllers
{
    public class HomeController : Controller
    {
        protected string _url;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Run()
        {
            TempData["message"] = "";
            try
            {
                new Travian().RunTest();
            }
            catch (Exception e)
            {

                TempData["message"] = e.Message + "<br/>" + e.StackTrace;
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void Browse()
        {
            Travian travian = new Travian();

            travian.SetupTest();
            travian.TheTravianTest();
            travian.TeardownTest();

            //using (WebBrowser browser = new WebBrowser())
            //{
            //    browser.Navigate(_url);

            //    //  browser.ClientSize = new Size(_width, _height);
            //    //browser.ScrollBarsEnabled = false;
            //    //browser.ScriptErrorsSuppressed = true;
            //    //browser.Navigate(_url);

            //    //// Wait for control to load page
            //    //while (browser.ReadyState != WebBrowserReadyState.Complete)
            //    //    Application.DoEvents();

            //    //html = browser.DocumentText;

            //}
        }

   
        //string html = "";
        //public string GetWebpage(string url)
        //{
        //    _url = url;
        //    // WebBrowser is an ActiveX control that must be run in a
        //    // single-threaded apartment so create a thread to create the
        //    // control and generate the thumbnail
        //    Thread thread = new Thread(new ThreadStart(GetWebPageWorker));
        //    thread.SetApartmentState(ApartmentState.STA);
        //    thread.Start();
        //    thread.Join();
        //    string s = html;
        //    return s;
        //}

        //protected void GetWebPageWorker()
        //{
        //    using (WebBrowser browser = new WebBrowser())
        //    {
        //        //  browser.ClientSize = new Size(_width, _height);
        //        browser.ScrollBarsEnabled = false;
        //        browser.ScriptErrorsSuppressed = true;
        //        browser.Navigate(_url);

        //        // Wait for control to load page
        //        while (browser.ReadyState != WebBrowserReadyState.Complete)
        //            Application.DoEvents();

        //        html = browser.DocumentText;

        //    }
        //}
    }
}