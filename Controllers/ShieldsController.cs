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
    public class ShieldsController : ApiController
    {
        private BorderlandsDataServicesContext db = new BorderlandsDataServicesContext();

        // GET: api/Shields
        public IQueryable<Shield> GetShields()
        {
            return db.Shields;
        }

        // GET: api/Shields/5
        [ResponseType(typeof(Shield))]
        public async Task<IHttpActionResult> GetShield(int id)
        {
            Shield shield = await db.Shields.FindAsync(id);
            if (shield == null)
            {
                return NotFound();
            }

            return Ok(shield);
        }

        // PUT: api/Shields/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutShield(int id, Shield shield)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shield.Id)
            {
                return BadRequest();
            }

            db.Entry(shield).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShieldExists(id))
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

        // POST: api/Shields
        [ResponseType(typeof(Shield))]
        public async Task<IHttpActionResult> PostShield(Shield shield)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Shields.Add(shield);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = shield.Id }, shield);
        }

        // DELETE: api/Shields/5
        [ResponseType(typeof(Shield))]
        public async Task<IHttpActionResult> DeleteShield(int id)
        {
            Shield shield = await db.Shields.FindAsync(id);
            if (shield == null)
            {
                return NotFound();
            }

            db.Shields.Remove(shield);
            await db.SaveChangesAsync();

            return Ok(shield);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShieldExists(int id)
        {
            return db.Shields.Count(e => e.Id == id) > 0;
        }
    }
}