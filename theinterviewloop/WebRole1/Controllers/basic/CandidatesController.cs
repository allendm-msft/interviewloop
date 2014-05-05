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
    public class CandidatesController : ApiController
    {
        private CandidateContext db = new CandidateContext();

        // GET: api/Candidates
        public IQueryable<Candidate> GetCandidates()
        {
            return db.Candidates;
        }

        // GET: api/Candidates/5
        [ResponseType(typeof(Candidate))]
        public async Task<IHttpActionResult> GetCandidate(int id)
        {
            Candidate candidate = await db.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }

        // PUT: api/Candidates/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCandidate(int id, Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidate.CandidateId)
            {
                return BadRequest();
            }

            db.Entry(candidate).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(id))
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

        // POST: api/Candidates
        [ResponseType(typeof(Candidate))]
        public async Task<IHttpActionResult> PostCandidate(Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Candidates.Add(candidate);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = candidate.CandidateId }, candidate);
        }

        // DELETE: api/Candidates/5
        [ResponseType(typeof(Candidate))]
        public async Task<IHttpActionResult> DeleteCandidate(int id)
        {
            Candidate candidate = await db.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            db.Candidates.Remove(candidate);
            await db.SaveChangesAsync();

            return Ok(candidate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CandidateExists(int id)
        {
            return db.Candidates.Count(e => e.CandidateId == id) > 0;
        }
    }
}