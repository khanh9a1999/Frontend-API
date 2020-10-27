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
using APILastBackend.Models;

namespace APILastBackend.Controllers
{
    public class SachesController : ApiController
    {
        private qlsachEntities db = new qlsachEntities();

        // GET: api/Saches
        [Route("api/Sach/all")]
        public IQueryable<Sach> GetSach()
        {
            return db.Sach;
        }
        [Route("api/Sach/by-name/{name}")]
        public IQueryable<Sach> GetSach(string name)
        {
            var kq=db.Sach.Where(s=>s.Tensach==name);
            return kq;
        }
        [Route("api/Sach/by-author/{tg}")]
        public IQueryable<Sach> GetSach(string tg)
        {
            var kq=db.Sach.Where(s=>s.Tacgia ==tg);
            return kq;
        }
          [Route("api/Sach/by-pb-comp/{nxb}")]
        public IQueryable<Sach> GetSach(string nxb)
        {
            var kq=db.Sach.Where(s=>s.Nhaxuatban ==nxb);
            return kq;
        }
        // GET: api/Saches/5
        [Route("api/Sach/detail/{id}")]
        [ResponseType(typeof(Sach))]
        public IHttpActionResult GetSach(int id)
        {
            Sach sach = db.Sach.Find(id);
            if (sach == null)
            {
                return NotFound();
            }

            return Ok(sach);
        }

        // PUT: api/Saches/5
        [Route("api/Sach/put/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSach(int id, Sach sach)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sach.Masach)
            {
                return BadRequest();
            }

            db.Entry(sach).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SachExists(id))
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

        // POST: api/Saches
        [Route("api/Sach/add")]
        [ResponseType(typeof(Sach))]
        public IHttpActionResult PostSach(Sach sach)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sach.Add(sach);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sach.Masach }, sach);
        }

        // DELETE: api/Saches/5
        [Route("api/Sach/delete/{id}")]
        [ResponseType(typeof(Sach))]
        public IHttpActionResult DeleteSach(int id)
        {
            Sach sach = db.Sach.Find(id);
            if (sach == null)
            {
                return NotFound();
            }

            db.Sach.Remove(sach);
            db.SaveChanges();

            return Ok(sach);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SachExists(int id)
        {
            return db.Sach.Count(e => e.Masach == id) > 0;
        }
    }
}
