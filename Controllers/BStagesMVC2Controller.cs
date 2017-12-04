using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CompanyDbWebAPI.ModelsDB;
using System.Diagnostics;

namespace CompanyDbWebAPI.Controllers
{
    public class BStagesMVC2Controller : Controller
    {
        private EVOYDB db = new EVOYDB();

        // GET: BStagesMVC2
        public ActionResult Index()
        {
            return View(db.BStages.ToList());
        }

        // GET: BStagesMVC2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BStage bStage = db.BStages.Find(id);
            if (bStage == null)
            {
                return HttpNotFound();
            }
            return View(bStage);
        }

        // GET: BStagesMVC2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BStagesMVC2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FullReference,Status,FromDate,ToDate,Consultant")] BStage bStage)
        {
            if (ModelState.IsValid)
            {
                db.BStages.Add(bStage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bStage);
        }

        // GET: BStagesMVC2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BStage bStage = db.BStages.Find(id);
            if (bStage == null)
            {
                return HttpNotFound();
            }
            return View(bStage);
        }

        // POST: BStagesMVC2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FullReference,Status,FromDate,ToDate,Consultant")] BStage bStage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bStage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bStage);
        }

        // GET: BStagesMVC2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BStage bStage = db.BStages.Find(id);
            if (bStage == null)
            {
                return HttpNotFound();
            }
            return View(bStage);
        }

        // POST: BStagesMVC2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BStage bStage = db.BStages.Find(id);
            db.BStages.Remove(bStage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //public ActionResult CloseInternetExplorer()
        //{

        //    Process[] AllProcesses = Process.GetProcesses();
        //    foreach (Process process in AllProcesses)
        //    {
        //        if (process.MainWindowTitle != "")
        //        {
        //            string s = process.ProcessName.ToLower();
        //            if (s == "iexplore")
        //            {
        //                //process.Kill();
        //                System.Threading.Thread.Sleep(10000);
        //                process.Close();
        //            }

        //        }
        //    }



        //    return null;
        //}

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
