using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BorderlandsDataServices.Data;
using BorderlandsDataServices.Models;

namespace BorderlandsDataServices.Controllers
{
    public class ArmorsController : ApiController
    {
        private BorderlandsDataServicesContext db = new BorderlandsDataServicesContext();

        // GET: api/Armors
        public IQueryable<Armor> GetArmors()
        {
            return db.Armors;
        }

        // GET: api/Armors/5
        [ResponseType(typeof(Armor))]
        public async Task<IHttpActionResult> GetArmor(int id)
        {
            Armor armor = await db.Armors.FindAsync(id);
            if (armor == null)
            {
                return NotFound();
            }

            return Ok(armor);
        }

        // PUT: api/Armors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutArmor(int id, Armor armor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != armor.Id)
            {
                return BadRequest();
            }

            db.Entry(armor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArmorExists(id))
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

        // POST: api/Armors
        [ResponseType(typeof(Armor))]
        public async Task<IHttpActionResult> PostArmor(Armor armor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Armors.Add(armor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = armor.Id }, armor);
        }

        // DELETE: api/Armors/5
        [ResponseType(typeof(Armor))]
        public async Task<IHttpActionResult> DeleteArmor(int id)
        {
            Armor armor = await db.Armors.FindAsync(id);
            if (armor == null)
            {
                return NotFound();
            }

            db.Armors.Remove(armor);
            await db.SaveChangesAsync();

            return Ok(armor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArmorExists(int id)
        {
            return db.Armors.Count(e => e.Id == id) > 0;
        }
    }
}