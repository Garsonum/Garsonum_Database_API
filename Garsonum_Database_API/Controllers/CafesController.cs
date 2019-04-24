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
using Garsonum_Database_API.Models;

namespace Garsonum_Database_API.Controllers
{
    public class CafesController : ApiController
    {
        private GarsonumEntities db = new GarsonumEntities();

        // GET: api/Cafes
        public IQueryable<Cafe> GetCafe()
        {
            return db.Cafe;
        }

        // GET: api/Cafes/5
        [ResponseType(typeof(Cafe))]
        public IHttpActionResult GetCafe(int id)
        {
            Cafe cafe = db.Cafe.Find(id);
            if (cafe == null)
            {
                return NotFound();
            }

            return Ok(cafe);
        }

        // PUT: api/Cafes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCafe(int id, Cafe cafe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cafe.c_id)
            {
                return BadRequest();
            }

            db.Entry(cafe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CafeExists(id))
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

        // POST: api/Cafes
        [ResponseType(typeof(Cafe))]
        public IHttpActionResult PostCafe(Cafe cafe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cafe.Add(cafe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cafe.c_id }, cafe);
        }

        // DELETE: api/Cafes/5
        [ResponseType(typeof(Cafe))]
        public IHttpActionResult DeleteCafe(int id)
        {
            Cafe cafe = db.Cafe.Find(id);
            if (cafe == null)
            {
                return NotFound();
            }

            db.Cafe.Remove(cafe);
            db.SaveChanges();

            return Ok(cafe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CafeExists(int id)
        {
            return db.Cafe.Count(e => e.c_id == id) > 0;
        }
    }
}