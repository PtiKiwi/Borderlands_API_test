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
    public class LootsController : ApiController
    {
        private BorderlandsDataServicesContext db = new BorderlandsDataServicesContext();

        // GET: api/Loots
        public IQueryable<Loot> GetLoots()
        {
            return db.Loots;
        }

        // GET: api/Loots/5
        [ResponseType(typeof(Loot))]
        public async Task<IHttpActionResult> GetLoot(int id)
        {
            Loot loot = await db.Loots.FindAsync(id);
            if (loot == null)
            {
                return NotFound();
            }

            return Ok(loot);
        }

        // PUT: api/Loots/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLoot(int id, Loot loot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loot.Id)
            {
                return BadRequest();
            }

            db.Entry(loot).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LootExists(id))
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

        // POST: api/Loots
        [ResponseType(typeof(Loot))]
        public async Task<IHttpActionResult> PostLoot(Loot loot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Loots.Add(loot);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = loot.Id }, loot);
        }

        // DELETE: api/Loots/5
        [ResponseType(typeof(Loot))]
        public async Task<IHttpActionResult> DeleteLoot(int id)
        {
            Loot loot = await db.Loots.FindAsync(id);
            if (loot == null)
            {
                return NotFound();
            }

            db.Loots.Remove(loot);
            await db.SaveChangesAsync();

            return Ok(loot);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LootExists(int id)
        {
            return db.Loots.Count(e => e.Id == id) > 0;
        }
    }
}