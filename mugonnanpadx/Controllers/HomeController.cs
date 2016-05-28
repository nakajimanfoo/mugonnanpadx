using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mugonnanpadx.Models;
using System.Net;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;


namespace mugonnanpadx.Controllers
{
    public class HomeController : Controller
    {


        private MugonDBContext db = new MugonDBContext();

        public ActionResult Index()
        {
            //
            if (Request.IsAuthenticated)
            {
                var mugonMessages = db.MugonMessages.Where(x => x.UserID == User.Identity.Name);
                foreach (MugonMessage mugonMessage in mugonMessages)
                {
                    ViewBag.Message = mugonMessage.Message;
                    return View();
                }
            }

            ViewBag.Message = "茶でもしばかんけ？";
            return View();
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

        public ActionResult Yes()
        {
            return View();
        }
        public ActionResult No()
        {
            return View();
        }

        // GET: MugonMessages/Edit/5
        public ActionResult SetMessage()
        {
            //System.Diagnostics.Trace.WriteLine(User.Identity.GetUserId());
           // System.Diagnostics.Trace.WriteLine(User.Identity.);
            if (User.Identity.GetUserId() == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return Index();
            }
            //ViewBag.UserID = User.Identity.GetUserId();

            var mugonMessages = db.MugonMessages.Where(x => x.UserID == User.Identity.Name);
            foreach (MugonMessage mugonMessage in mugonMessages)
            {
                ViewBag.ExistData = true;
                return View(mugonMessage);
            }
            ViewBag.ExistData = false;
            return View();

            //MugonMessage mugonMessage = db.MugonMessages.Find(1);//db.MugonMessages.SqlQuery("SELECT * FROM dbo.MugenMessages a WHERE a.UserID = @UserID  ", new SqlParameter ("@UserID", ViewBag.UserID));
            //if (mugonMessage == null)
            //{
            //    ViewBag.ExistData = false;
            //    //return HttpNotFound();
            //    return View();
            //}
            //ViewBag.ExistData = true;
            //    return View(mugonMessage);
        }

        // POST: MugonMessages/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetMessage([Bind(Include = "ID,Message,Yes,No,UserID")] MugonMessage mugonMessage)
        {

            //System.Diagnostics.Trace.WriteLine(mugonMessage.UserID);
            if (ModelState.IsValid)
            {
                var mugonMessages = db.MugonMessages.Where(x => x.UserID == User.Identity.Name);
                
                if (mugonMessages.Count() == 0)
                {
                    mugonMessage.UserID = User.Identity.Name;
                    db.MugonMessages.Add(mugonMessage);
                }
                else
                {
                    db.Entry(mugonMessage).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mugonMessage);
        }




    }
}