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
    public class TrackerController : ApiController
    {
        private TrackerContext db = new TrackerContext();

        // GET api/Tracker
        public IEnumerable<Tracker> GetTrackers()
        {
            return db.Trackers.AsEnumerable();
        }

        // GET api/Tracker/5
        public Tracker GetTracker(int id)
        {
            Tracker tracker = db.Trackers.Find(id);
            if (tracker == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return tracker;
        }

        // PUT api/Tracker/5
        public HttpResponseMessage PutTracker(int id, Tracker tracker)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != tracker.TrackerId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(tracker).State = EntityState.Modified;

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

        // POST api/Tracker
        public HttpResponseMessage PostTracker(Tracker tracker)
        {
            if (ModelState.IsValid)
            {
                db.Trackers.Add(tracker);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, tracker);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = tracker.TrackerId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Tracker/5
        public HttpResponseMessage DeleteTracker(int id)
        {
            Tracker tracker = db.Trackers.Find(id);
            if (tracker == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Trackers.Remove(tracker);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, tracker);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}