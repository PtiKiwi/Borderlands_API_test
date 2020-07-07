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
    public class WeaponsController : ApiController
    {
        private BorderlandsDataServicesContext db = new BorderlandsDataServicesContext();

        // GET: api/Weapons
        public IQueryable<Weapon> GetWeapons()
        {
            return db.Weapons;
        }

        // GET: api/Weapons/5
        [ResponseType(typeof(Weapon))]
        public async Task<IHttpActionResult> GetWeapon(int id)
        {
            Weapon weapon = await db.Weapons.FindAsync(id);
            if (weapon == null)
            {
                return NotFound();
            }

            return Ok(weapon);
        }

        // PUT: api/Weapons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWeapon(int id, Weapon weapon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != weapon.Id)
            {
                return BadRequest();
            }

            db.Entry(weapon).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeaponExists(id))
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

        // POST: api/Weapons
        [ResponseType(typeof(Weapon))]
        public async Task<IHttpActionResult> PostWeapon(Weapon weapon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Weapons.Add(weapon);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = weapon.Id }, weapon);
        }

        // DELETE: api/Weapons/5
        [ResponseType(typeof(Weapon))]
        public async Task<IHttpActionResult> DeleteWeapon(int id)
        {
            Weapon weapon = await db.Weapons.FindAsync(id);
            if (weapon == null)
            {
                return NotFound();
            }

            db.Weapons.Remove(weapon);
            await db.SaveChangesAsync();

            return Ok(weapon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WeaponExists(int id)
        {
            return db.Weapons.Count(e => e.Id == id) > 0;
        }
    }
}