using MedicalAssistant_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalAssistant_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthMetricsController : Controller
    {
        private readonly MedicalAssistantContext _context;

        public HealthMetricsController(MedicalAssistantContext context)
        {
            _context = context;
        }

        // GET: api/HealthMetrics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HealthMetric>>> GetHealthMetrics()
        {
            return await _context.HealthMetrics.ToListAsync();
        }

        // GET: api/HealthMetrics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HealthMetric>> GetHealthMetrics(int id)
        {
            var healthMetrics = await _context.HealthMetrics.FindAsync(id);

            if (healthMetrics == null)
            {
                return NotFound();
            }

            return healthMetrics;
        }

        // PUT: api/HealthMetrics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHealthMetrics(int id, HealthMetric healthMetrics)
        {
            if (id != healthMetrics.MetricID)
            {
                return BadRequest();
            }

            _context.Entry(healthMetrics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HealthMetricsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HealthMetrics
        [HttpPost]
        public async Task<ActionResult<HealthMetric>> PostHealthMetrics(HealthMetric healthMetrics)
        {
            _context.HealthMetrics.Add(healthMetrics);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHealthMetrics", new { id = healthMetrics.MetricID }, healthMetrics);
        }

        // DELETE: api/HealthMetrics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHealthMetrics(int id)
        {
            var healthMetrics = await _context.HealthMetrics.FindAsync(id);
            if (healthMetrics == null)
            {
                return NotFound();
            }

            _context.HealthMetrics.Remove(healthMetrics);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HealthMetricsExists(int id)
        {
            return _context.HealthMetrics.Any(e => e.MetricID == id);
        }
    }
}
