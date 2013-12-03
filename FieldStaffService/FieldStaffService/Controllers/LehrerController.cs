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
using System.Data.SqlClient;

namespace FieldStaffService.Controllers
{
    public class LehrerController : ApiController
    {
        private LehrerContext db = new LehrerContext();

        // GET api/Lehrer
        public IEnumerable<Lehrer> GetLehrers(int schuleid)
        {
            IEnumerable<Lehrer> lehrerlist = db.Lehrers.SqlQuery(@"
Select	k.kundeid, k.anrede, k.vorname, k.name, k.telp, k.telg,k.telp,
	k.email,k.bemerkung,k.kstatusid,k.beziehungid,

	tvfest.terminverwaltungid as festterminverwaltungid,	
	afest.arbeiterid as festarbeiterid, afest.benutzername as festbenutzername,
	tvfest.terminartid as festterminartid, tvfest.terminstart as festterminstart,
	tvfest.terminende as festterminende,
	
	tvvonbis.terminverwaltungid as vonbisterminverwaltungid,	
	avonbis.arbeiterid as vonbisarbeiterid, avonbis.benutzername as vonbisbenutzername,
	tvvonbis.terminartid as vonbisterminartid, tvvonbis.terminstart as vonbisterminstart,
	tvvonbis.terminende as vonbisterminende
	
	
	from kunde k
	left join ktermin ktfest on k.kundeid=ktfest.kundeid
	left join terminverwaltung tvfest on ktfest.terminverwaltungid=tvfest.terminverwaltungid
	left join arbeiter afest on tvfest.arbeiterid=afest.arbeiterid 
	
	left join ktermin ktvonbis on k.kundeid=ktvonbis.kundeid
	left join terminverwaltung tvvonbis on ktvonbis.terminverwaltungid=tvvonbis.terminverwaltungid
	left join arbeiter avonbis on tvvonbis.arbeiterid=avonbis.arbeiterid 
	where
    k.kstatusid!=99 and
    ( tvfest.terminverwaltungid=(
		Select max(tv.terminverwaltungid) from terminverwaltung tv 
		join ktermin kt on tv.terminverwaltungid=kt.terminverwaltungid 
		where tv.terminartid=1 and kt.kundeid=k.kundeid
		Group by kt.kundeid
	) OR (
		Select max(tv.terminverwaltungid) from terminverwaltung tv 
		join ktermin kt on tv.terminverwaltungid=kt.terminverwaltungid 
		where tv.terminartid=1 and kt.kundeid=k.kundeid
		Group by kt.kundeid
	) IS NULL)
	and( tvvonbis.terminverwaltungid=(
		Select max(tv.terminverwaltungid) from terminverwaltung tv 
		join ktermin kt on tv.terminverwaltungid=kt.terminverwaltungid 
		where tv.terminartid!=1 and kt.kundeid=k.kundeid
		and tv.terminende>SYSDATETIME()
		Group by kt.kundeid
	) OR (
		Select max(tv.terminverwaltungid) from terminverwaltung tv 
		join ktermin kt on tv.terminverwaltungid=kt.terminverwaltungid 
		where tv.terminartid!=1 and kt.kundeid=k.kundeid
		and tv.terminende>SYSDATETIME()
		Group by kt.kundeid
	) IS NULL)
	and k.organisationid=@organisationid",new SqlParameter("organisationid",schuleid));

            return lehrerlist;
        }

        // GET api/Lehrer/5
        public Lehrer GetLehrer(int id)
        {
            Lehrer lehrer = db.Lehrers.SqlQuery(@"
Select	k.kundeid, k.anrede, k.vorname, k.name, k.telp, k.telg,k.telp,
	k.email,k.bemerkung,k.kstatusid,k.beziehungid,

	tvfest.terminverwaltungid as festterminverwaltungid,	
	afest.arbeiterid as festarbeiterid, afest.benutzername as festbenutzername,
	tvfest.terminartid as festterminartid, tvfest.terminstart as festterminstart,
	tvfest.terminende as festterminende,
	
	tvvonbis.terminverwaltungid as vonbisterminverwaltungid,	
	avonbis.arbeiterid as vonbisarbeiterid, avonbis.benutzername as vonbisbenutzername,
	tvvonbis.terminartid as vonbisterminartid, tvvonbis.terminstart as vonbisterminstart,
	tvvonbis.terminende as vonbisterminende
	
	
	from kunde k
	left join ktermin ktfest on k.kundeid=ktfest.kundeid
	left join terminverwaltung tvfest on ktfest.terminverwaltungid=tvfest.terminverwaltungid
	left join arbeiter afest on tvfest.arbeiterid=afest.arbeiterid 
	
	left join ktermin ktvonbis on k.kundeid=ktvonbis.kundeid
	left join terminverwaltung tvvonbis on ktvonbis.terminverwaltungid=tvvonbis.terminverwaltungid
	left join arbeiter avonbis on tvvonbis.arbeiterid=avonbis.arbeiterid 
	where
     k.kstatusid!=99 and
    ( tvfest.terminverwaltungid=(
		Select max(tv.terminverwaltungid) from terminverwaltung tv 
		join ktermin kt on tv.terminverwaltungid=kt.terminverwaltungid 
		where tv.terminartid=1 and kt.kundeid=k.kundeid
		Group by kt.kundeid
	) OR (
		Select max(tv.terminverwaltungid) from terminverwaltung tv 
		join ktermin kt on tv.terminverwaltungid=kt.terminverwaltungid 
		where tv.terminartid=1 and kt.kundeid=k.kundeid
		Group by kt.kundeid
	) IS NULL)
	and( tvvonbis.terminverwaltungid=(
		Select max(tv.terminverwaltungid) from terminverwaltung tv 
		join ktermin kt on tv.terminverwaltungid=kt.terminverwaltungid 
		where tv.terminartid!=1 and kt.kundeid=k.kundeid
		and tv.terminende>SYSDATETIME()
		Group by kt.kundeid
	) OR (
		Select max(tv.terminverwaltungid) from terminverwaltung tv 
		join ktermin kt on tv.terminverwaltungid=kt.terminverwaltungid 
		where tv.terminartid!=1 and kt.kundeid=k.kundeid
		and tv.terminende>SYSDATETIME()
		Group by kt.kundeid
	) IS NULL)
	and k.kundeid=@kundeid", new SqlParameter("kundeid",id)).FirstOrDefault();
            if (lehrer == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return lehrer;
        }

        // PUT api/Lehrer/5
        public HttpResponseMessage PutLehrer(int id, Lehrer lehrer)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != lehrer.kundeid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(lehrer).State = EntityState.Modified;

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

        // POST api/Lehrer
        public HttpResponseMessage PostLehrer(Lehrer lehrer)
        {
            if (ModelState.IsValid)
            {
                db.Lehrers.Add(lehrer);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, lehrer);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = lehrer.kundeid }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Lehrer/5
        public HttpResponseMessage DeleteLehrer(int id)
        {
            Lehrer lehrer = db.Lehrers.Find(id);
            if (lehrer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Lehrers.Remove(lehrer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, lehrer);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}