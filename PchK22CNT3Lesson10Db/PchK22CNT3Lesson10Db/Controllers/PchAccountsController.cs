using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PchK22CNT3Lesson10Db.Models;

namespace PchK22CNT3Lesson10Db.Controllers
{
    public class PchAccountsController : Controller
    {
        private PchK22CNT3Lesson10DbEntities db = new PchK22CNT3Lesson10DbEntities();

        // GET: PchAccounts
        public ActionResult Index()
        {
            return View(db.PchAccounts.ToList());
        }

        // GET: PchAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PchAccount pchAccount = db.PchAccounts.Find(id);
            if (pchAccount == null)
            {
                return HttpNotFound();
            }
            return View(pchAccount);
        }

        // GET: PchAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PchAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PchUserName,PchPassword,PchFullName,PchEmail,PchPhone,PchActive,PchID")] PchAccount pchAccount)
        {
            if (ModelState.IsValid)
            {
                db.PchAccounts.Add(pchAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pchAccount);
        }

        // GET: PchAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PchAccount pchAccount = db.PchAccounts.Find(id);
            if (pchAccount == null)
            {
                return HttpNotFound();
            }
            return View(pchAccount);
        }

        // POST: PchAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PchUserName,PchPassword,PchFullName,PchEmail,PchPhone,PchActive,PchID")] PchAccount pchAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pchAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pchAccount);
        }

        // GET: PchAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PchAccount pchAccount = db.PchAccounts.Find(id);
            if (pchAccount == null)
            {
                return HttpNotFound();
            }
            return View(pchAccount);
        }

        // POST: PchAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PchAccount pchAccount = db.PchAccounts.Find(id);
            db.PchAccounts.Remove(pchAccount);
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
        // login
        public ActionResult PchLogin()
        {
            var PchModel = new PchAccount();
            return View();
        }
        [HttpPost]
        public ActionResult PchLogin(PchAccount pchAccount)
        {
            var pchCheck = db.PchAccounts.Where(x => x.PchUserName.Equals(pchAccount.PchUserName) && x.PchPassword.Equals(pchAccount.PchPassword)).FirstOrDefault();  
            if (pchCheck != null)
            {
                // luu session
                Session["PchAccount"] = pchCheck;
                return Redirect("/");
            }    
                return View(pchAccount);
        }
    }
}
