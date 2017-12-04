using CompanyDbWebAPI.ModelsDB;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace CompanyDbWebAPI.Controllers
{
    public class TBALocationsController : ApiController
    {
        private EVOYDB db = new EVOYDB();

        // GET: api/TBALocations
        public IHttpActionResult GetTBALocations()
        {
            using (EVOYDB eContext = new EVOYDB())
            {
                eContext.Configuration.ProxyCreationEnabled = false;
                return Ok(eContext.TBALocations.ToList());
            }

        }

        // GET: api/TBALocations/5
        [ResponseType(typeof(TBALocation))]
        public IHttpActionResult GetTBALocation(string id)
        {
            TBALocation tBALocation = db.TBALocations.Find(id);
            if (tBALocation == null)
            {
                return NotFound();
            }

            return Ok(tBALocation);
        }

        // PUT: api/TBALocations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTBALocation(string id, TBALocation tBALocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tBALocation.CODE)
            {
                return BadRequest();
            }

            db.Entry(tBALocation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TBALocationExists(id))
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

        // POST: api/TBALocations
        [ResponseType(typeof(TBALocation))]
        public IHttpActionResult PostTBALocation(TBALocation tBALocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TBALocations.Add(tBALocation);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TBALocationExists(tBALocation.CODE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tBALocation.CODE }, tBALocation);
        }

        // DELETE: api/TBALocations/5
        [ResponseType(typeof(TBALocation))]
        public IHttpActionResult DeleteTBALocation(string id)
        {
            TBALocation tBALocation = db.TBALocations.Find(id);
            if (tBALocation == null)
            {
                return NotFound();
            }

            db.TBALocations.Remove(tBALocation);
            db.SaveChanges();

            return Ok(tBALocation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TBALocationExists(string id)
        {
            return db.TBALocations.Count(e => e.CODE == id) > 0;
        }
    }
}