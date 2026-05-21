using Application;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : BaseApiController
    {
        
        private readonly IActivityService _activityservice;
        public ActivitiesController(IActivityService service)
        {
            _activityservice = service;
        }

     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadActivityDto>>> GetActivities()
        {
           var activities = await _activityservice.GetActivitiesAsync();
           if (!activities.Any())
            {
                return NotFound();
            }

            return Ok(activities);
        }

        
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FullActivityDto>> GetActivityById(Guid id)
        {
            var activity = await _activityservice.GetActivityAsync(id);

            if(activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        [HttpPost]
        public async Task<ActionResult<ReadActivityDto>> CreateActivity(CreateActivityDto dto)
        {
            var created = await _activityservice.CreateActivity(dto);

            //return Created("Activity created", activity);
            return CreatedAtAction(nameof(GetActivityById), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditActivity(FullActivityDto activity)
        {
            await _activityservice.EditActivity(activity);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            await _activityservice.DeleteActivity(id);
            return NoContent();
        }
    }
}
