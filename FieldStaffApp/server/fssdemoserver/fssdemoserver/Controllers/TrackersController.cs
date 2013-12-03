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
using fssdemoserver.Models;

namespace fssdemoserver.Controllers
{
    public class TrackersController : ApiController
    {
        private TrackersContext db = new TrackersContext();
        
        

        // GET api/Trackers/5
        public Tracker GetTracker(int id)
        {
            Tracker tracker = db.Trackers.Find(id);
            if (tracker == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return tracker;
        }

        public IQueryable<Tracker> GetTrackers()
        {
            return db.Trackers.AsQueryable();
        }


        // PUT api/Trackers/5
        public HttpResponseMessage PutTracker(int id, Tracker tracker)
        {
            if (ModelState.IsValid && id == tracker.TrackerId)
            {
                db.Entry(tracker).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Trackers
        public HttpResponseMessage PostTracker([FromBody] Tracker tracker)
        {
            if (ModelState.IsValid)
            {
                if (tracker.TrackTime.Year < 2000)
                {
                    tracker.TrackTime = DateTime.Now;
                }
                db.Trackers.Add(tracker);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, tracker);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = tracker.TrackerId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Trackers/5
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
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
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