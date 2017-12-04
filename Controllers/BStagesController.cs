using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CompanyDbWebAPI.ModelsDB;

namespace CompanyDbWebAPI.Controllers
{
    public class BStagesController : ApiController
    {
        private EVOYDB db = new EVOYDB();

        // GET: api/BStages
        public IQueryable<BStage> GetBStages()
        {
            return db.BStages;
        }

        // GET: api/BStages/5
        [ResponseType(typeof(BStage))]
        public IHttpActionResult GetBStage(int id)
        {
            BStage bStage = db.BStages.Find(id);
            if (bStage == null)
            {
                return NotFound();
            }

            return Ok(bStage);
        }

        // PUT: api/BStages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBStage(int id, BStage bStage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bStage.id)
            {
                return BadRequest();
            }

            db.Entry(bStage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BStageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BStages
        [ResponseType(typeof(BStage))]
        public IHttpActionResult PostBStage(BStage bStage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BStages.Add(bStage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bStage.id }, bStage);
        }

        // DELETE: api/BStages/5
        [ResponseType(typeof(BStage))]
        public IHttpActionResult DeleteBStage(int id)
        {
            BStage bStage = db.BStages.Find(id);
            if (bStage == null)
            {
                return NotFound();
            }

            db.BStages.Remove(bStage);
            db.SaveChanges();

            return Ok(bStage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BStageExists(int id)
        {
            return db.BStages.Count(e => e.id == id) > 0;
        }
    }
}