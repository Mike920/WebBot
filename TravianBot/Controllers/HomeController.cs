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
                Travian.RunTest();
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
        }

        private object ThisLock = new object();

        [HttpPost]
        public string StoreInfo(string text)
        {
            lock (this.ThisLock)
            {
                if (base.HttpContext.Application["info"] == null)
                {
                    base.HttpContext.Application["info"] = new List<string>();
                }
                List<string> list = (List<string>)base.HttpContext.Application["info"];
                list.Add(text);
                base.HttpContext.Application["info"] = list;
            }

            return "OK";
        }

    }
}