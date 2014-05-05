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
using WebRole1.Models;

namespace WebRole1.Controllers
{
    public class InterviewersController : ApiController
    {
        private InterviewerContext db = new InterviewerContext();

        // GET: api/Interviewers
        public IQueryable<Interviewer> GetInterviewers()
        {
            return db.Interviewers;
        }

        // GET: api/Interviewers/5
        [ResponseType(typeof(Interviewer))]
        public async Task<IHttpActionResult> GetInterviewer(int id)
        {
            Interviewer interviewer = await db.Interviewers.FindAsync(id);
            if (interviewer == null)
            {
                return NotFound();
            }

            return Ok(interviewer);
        }

        // PUT: api/Interviewers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInterviewer(int id, Interviewer interviewer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != interviewer.InterviewerId)
            {
                return BadRequest();
            }

            db.Entry(interviewer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterviewerExists(id))
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

        // POST: api/Interviewers
        [ResponseType(typeof(Interviewer))]
        public async Task<IHttpActionResult> PostInterviewer(Interviewer interviewer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Interviewers.Add(interviewer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = interviewer.InterviewerId }, interviewer);
        }

        // DELETE: api/Interviewers/5
        [ResponseType(typeof(Interviewer))]
        public async Task<IHttpActionResult> DeleteInterviewer(int id)
        {
            Interviewer interviewer = await db.Interviewers.FindAsync(id);
            if (interviewer == null)
            {
                return NotFound();
            }

            db.Interviewers.Remove(interviewer);
            await db.SaveChangesAsync();

            return Ok(interviewer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InterviewerExists(int id)
        {
            return db.Interviewers.Count(e => e.InterviewerId == id) > 0;
        }
    }
}