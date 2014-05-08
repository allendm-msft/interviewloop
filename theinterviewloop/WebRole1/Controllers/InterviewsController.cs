using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebRole1.Models;

namespace WebRole1.Controllers.basic
{
    public class InterviewsController : ApiController
    {
        private InterviewLoopContext db = new InterviewLoopContext();

        // GET: api/Interviews
        public IQueryable<Interview> GetInterviews()
        {
            return db.Interviews;
        }

        // GET: api/Interviews/5
        [ResponseType(typeof(Interview))]
        public async Task<IHttpActionResult> GetInterview(int id)
        {
            Interview interview = await db.Interviews.FindAsync(id);
            if (interview == null)
            {
                return NotFound();
            }

            return Ok(interview);
        }

        // PUT: api/Interviews/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInterview(int id, Interview interview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != interview.InterviewId)
            {
                return BadRequest();
            }

            db.Entry(interview).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterviewExists(id))
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

        // POST: api/Interviews
        [ResponseType(typeof(Interview))]
        public async Task<IHttpActionResult> PostInterview(Interview interview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Interviews.Add(interview);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = interview.InterviewId }, interview);
        }

        // DELETE: api/Interviews/5
        [ResponseType(typeof(Interview))]
        public async Task<IHttpActionResult> DeleteInterview(int id)
        {
            Interview interview = await db.Interviews.FindAsync(id);
            if (interview == null)
            {
                return NotFound();
            }

            db.Interviews.Remove(interview);
            await db.SaveChangesAsync();

            return Ok(interview);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InterviewExists(int id)
        {
            return db.Interviews.Count(e => e.InterviewId == id) > 0;
        }
    }
}