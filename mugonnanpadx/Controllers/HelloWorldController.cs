using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mugonnanpadx.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        //public string Index()
        {
            //return "Hello World";
            return View();
        }


        public ActionResult Welcome()
        {
            return View();
        }

    }
}