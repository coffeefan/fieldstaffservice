using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using FieldStaffService.Models;

namespace FieldStaffService.Controllers
{
    public class OrtController : ApiController
    {
        private OrtContext db = new OrtContext();

        // GET api/Ort
        //[Authorize(Roles = "fotograf")]
        public IEnumerable<Ort> GetOrts()
        {
            return db.Orts.AsEnumerable();
        }

        // GET api/Ort/5
        [Authorize(Roles = "fotograf")]
        public Ort GetOrt(int id)
        {
            Ort ort = db.Orts.Find(id);
            if (ort == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return ort;
        }

        // PUT api/Ort/5
        public HttpResponseMessage PutOrt(int id, Ort ort)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != ort.ortid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(ort).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Ort
        public HttpResponseMessage PostOrt(Ort ort)
        {
            if (ModelState.IsValid)
            {
                db.Orts.Add(ort);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, ort);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = ort.ortid }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Ort/5
        public HttpResponseMessage DeleteOrt(int id)
        {
            Ort ort = db.Orts.Find(id);
            if (ort == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Orts.Remove(ort);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, ort);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}