using CompanyDbWebAPI.ModelsDB;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CompanyDbWebAPI.Controllers
{
    // controller used to manually alter  the BStages table in the company db
    public class BStagesMVC3Controller : Controller
    {
        private EVOYDB db = new EVOYDB();

        // GET: BStagesMVC3
        public ActionResult Index()
        {

            //// save the data temporarily
            //string xmlFile = @"D:\MockData\BackedUpAllBStages.xml";
            //List<BStage> backedupData = db.BStages.ToList();
            //XmlSerializer s = new XmlSerializer(typeof(List<BStage>));
            //using (StreamWriter sw = new StreamWriter(xmlFile, false))
            //{
            //    s.Serialize(sw, backedupData);
            //}






            //// read the data from XML
            //XmlSerializer s = new XmlSerializer(typeof(List<BStage>));
            //using (StreamReader sr = new StreamReader(xmlFile))
            //{
            //    List<BStage> backedupData = s.Deserialize(sr) as List<BStage>;
            //    return View(backedupData);
            //}




            var t = db.BStages.ToList();

            return View(t);



        }

        // GET: BStagesMVC3/Details/5
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

        // GET: BStagesMVC3/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BStagesMVC3/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FullReference,Status,FromDate,ToDate,Consultant,Sales_Update")] BStage bStage)
        {
            if (ModelState.IsValid)
            {
                db.BStages.Add(bStage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bStage);
        }

        // GET: BStagesMVC3/Edit/5
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

        // POST: BStagesMVC3/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FullReference,Status,FromDate,ToDate,Consultant,Sales_Update")] BStage bStage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bStage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bStage);
        }

        // GET: BStagesMVC3/Delete/5
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

        // POST: BStagesMVC3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BStage bStage = db.BStages.Find(id);
            db.BStages.Remove(bStage);
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
