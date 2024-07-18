using MedicalAssistant_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalAssistant_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictionsController : ControllerBase
    {
        private readonly MedicalAssistantContext _context;

        public PredictionsController(MedicalAssistantContext context)
        {
            _context = context;
        }

        // GET: api/Predictions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prediction>>> GetPredictions()
        {
            return await _context.Predictions.ToListAsync();
        }

        // GET: api/Predictions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prediction>> GetPrediction(int id)
        {
            var prediction = await _context.Predictions.FindAsync(id);

            if (prediction == null)
            {
                return NotFound();
            }

            return prediction;
        }

        // PUT: api/Predictions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrediction(int id, Prediction prediction)
        {
            if (id != prediction.PredictionID)
            {
                return BadRequest();
            }

            _context.Entry(prediction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PredictionExists(id))
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

        // POST: api/Predictions
        [HttpPost]
        public async Task<ActionResult<Prediction>> PostPrediction(Prediction prediction)
        {
            _context.Predictions.Add(prediction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrediction", new { id = prediction.PredictionID }, prediction);
        }

        // DELETE: api/Predictions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrediction(int id)
        {
            var prediction = await _context.Predictions.FindAsync(id);
            if (prediction == null)
            {
                return NotFound();
            }

            _context.Predictions.Remove(prediction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PredictionExists(int id)
        {
            return _context.Predictions.Any(e => e.PredictionID == id);
        }
    }
}
