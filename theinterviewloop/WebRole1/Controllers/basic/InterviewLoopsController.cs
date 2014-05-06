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
    public class InterviewLoopsController : ApiController
    {
        private InterviewLoopContext db = new InterviewLoopContext();

        // GET: api/InterviewLoops
        public IQueryable<InterviewLoop> GetInterviewLoops()
        {
            return db.InterviewLoops;
        }

        // GET: api/InterviewLoops/5
        [ResponseType(typeof(InterviewLoop))]
        public async Task<IHttpActionResult> GetInterviewLoop(int id)
        {
            InterviewLoop interviewLoop = await db.InterviewLoops.FindAsync(id);
            if (interviewLoop == null)
            {
                return NotFound();
            }

            return Ok(interviewLoop);
        }

        // PUT: api/InterviewLoops/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInterviewLoop(int id, InterviewLoop interviewLoop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != interviewLoop.InterviewLoopId)
            {
                return BadRequest();
            }

            db.Entry(interviewLoop).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterviewLoopExists(id))
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

        // POST: api/InterviewLoops
        [ResponseType(typeof(InterviewLoop))]
        public async Task<IHttpActionResult> PostInterviewLoop(InterviewLoop interviewLoop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InterviewLoops.Add(interviewLoop);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = interviewLoop.InterviewLoopId }, interviewLoop);
        }

        // DELETE: api/InterviewLoops/5
        [ResponseType(typeof(InterviewLoop))]
        public async Task<IHttpActionResult> DeleteInterviewLoop(int id)
        {
            InterviewLoop interviewLoop = await db.InterviewLoops.FindAsync(id);
            if (interviewLoop == null)
            {
                return NotFound();
            }

            db.InterviewLoops.Remove(interviewLoop);
            await db.SaveChangesAsync();

            return Ok(interviewLoop);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InterviewLoopExists(int id)
        {
            return db.InterviewLoops.Count(e => e.InterviewLoopId == id) > 0;
        }
    }
}