using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mugonnanpadx.Models;

namespace mugonnanpadx.Controllers
{
    public class MugonMessagesController : Controller
    {
        private MugonDBContext db = new MugonDBContext();

        // GET: MugonMessages
        public ActionResult Index()
        {
            return View(db.MugonMessages.ToList());
        }

        // GET: MugonMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MugonMessage mugonMessage = db.MugonMessages.Find(id);
            if (mugonMessage == null)
            {
                return HttpNotFound();
            }
            return View(mugonMessage);
        }

        // GET: MugonMessages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MugonMessages/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Message,Yes,No,UserID")] MugonMessage mugonMessage)
        {
            if (ModelState.IsValid)
            {
                db.MugonMessages.Add(mugonMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mugonMessage);
        }

        // GET: MugonMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MugonMessage mugonMessage = db.MugonMessages.Find(id);
            if (mugonMessage == null)
            {
                return HttpNotFound();
            }
            return View(mugonMessage);
        }

        // POST: MugonMessages/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Message,Yes,No,UserID")] MugonMessage mugonMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mugonMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mugonMessage);
        }

        // GET: MugonMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MugonMessage mugonMessage = db.MugonMessages.Find(id);
            if (mugonMessage == null)
            {
                return HttpNotFound();
            }
            return View(mugonMessage);
        }

        // POST: MugonMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MugonMessage mugonMessage = db.MugonMessages.Find(id);
            db.MugonMessages.Remove(mugonMessage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
