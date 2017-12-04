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

    // the API controller is only used to get or update the table "Log_Update"
    public class Log_UpdateController : ApiController
    {
        private EVOYDB db = new EVOYDB();

        // GET: api/Log_Update
        public IQueryable<Log_Update> GetLog_Updates()
        {
            return db.Log_Updates;
        }

        // GET: api/Log_Update/5
        [ResponseType(typeof(Log_Update))]
        public IHttpActionResult GetLog_Update(int id)
        {
            Log_Update log_Update = db.Log_Updates.Find(id);
            if (log_Update == null)
            {
                return NotFound();
            }

            return Ok(log_Update);
        }

        // PUT: api/Log_Update/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLog_Update(int id, Log_Update log_Update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != log_Update.id)
            {
                return BadRequest();
            }

            db.Entry(log_Update).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Log_UpdateExists(id))
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

        //// POST: api/Log_Update
        //[ResponseType(typeof(Log_Update))]
        //public IHttpActionResult PostLog_Update(Log_Update log_Update)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Log_Updates.Add(log_Update);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = log_Update.id }, log_Update);
        //}

        //// DELETE: api/Log_Update/5
        //[ResponseType(typeof(Log_Update))]
        //public IHttpActionResult DeleteLog_Update(int id)
        //{
        //    Log_Update log_Update = db.Log_Updates.Find(id);
        //    if (log_Update == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Log_Updates.Remove(log_Update);
        //    db.SaveChanges();

        //    return Ok(log_Update);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Log_UpdateExists(int id)
        {
            return db.Log_Updates.Count(e => e.id == id) > 0;
        }
    }
}