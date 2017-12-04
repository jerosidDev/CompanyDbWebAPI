using CompanyDbWebAPI.ModelsDB;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace CompanyDbWebAPI.Controllers
{
    public class ContractConsultantsController : ApiController
    {
        private EVOYDB db = new EVOYDB();

        // GET: api/ContractConsultants
        //public IHttpActionResult GetContractConsultants()
        //{

        //    using (EVOYDB eContext = new EVOYDB())
        //    {
        //        eContext.Configuration.ProxyCreationEnabled = false;
        //        return Ok(eContext.ContractConsultants.ToList());
        //    }

        //}


        // GET: api/ContractConsultants
        public IHttpActionResult GetContractConsultants2()
        {

            using (EVOYDB eContext = new EVOYDB())
            {
                eContext.Configuration.ProxyCreationEnabled = false;

                var q = eContext.ContractConsultants
                    .Include(cc => cc.LocationsAssigned)
                    .ToList();


                return Ok(q);
            }

        }


        // GET: api/ContractConsultants/5
        [ResponseType(typeof(ContractConsultant))]
        public IHttpActionResult GetContractConsultant(string id)
        {
            ContractConsultant contractConsultant = db.ContractConsultants.Find(id);
            if (contractConsultant == null)
            {
                return NotFound();
            }

            return Ok(contractConsultant);
        }

        // PUT: api/ContractConsultants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContractConsultant(string id, ContractConsultant contractConsultant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contractConsultant.INITIALS)
            {
                return BadRequest();
            }

            db.Entry(contractConsultant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractConsultantExists(id))
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

        // POST: api/ContractConsultants
        [ResponseType(typeof(ContractConsultant))]
        public IHttpActionResult PostContractConsultant(ContractConsultant contractConsultant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ContractConsultants.Add(contractConsultant);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ContractConsultantExists(contractConsultant.INITIALS))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = contractConsultant.INITIALS }, contractConsultant);
        }

        // DELETE: api/ContractConsultants/5
        [ResponseType(typeof(ContractConsultant))]
        public IHttpActionResult DeleteContractConsultant(string id)
        {
            ContractConsultant contractConsultant = db.ContractConsultants.Find(id);
            if (contractConsultant == null)
            {
                return NotFound();
            }

            db.ContractConsultants.Remove(contractConsultant);
            db.SaveChanges();

            return Ok(contractConsultant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContractConsultantExists(string id)
        {
            return db.ContractConsultants.Count(e => e.INITIALS == id) > 0;
        }
    }
}