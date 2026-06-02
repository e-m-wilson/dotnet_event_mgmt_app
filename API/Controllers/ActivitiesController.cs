using Application;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class ActivitiesController : BaseApiController<ActivitiesController>
    {
        
        private readonly IActivityService _activityservice;
        
        public ActivitiesController(
            IActivityService service,
            ILogger<ActivitiesController> logger,
            IMediator mediator
            ) : base(logger, mediator)
        {
            _activityservice = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FullActivityDto>>> GetActivities(CancellationToken ct)
        {
           Logger.LogInformation("Request to get all activities"); 
           var activities = await Mediator.Send(new GetActivityList.Query(), ct);
           if (!activities.Any())
            {
                return NotFound();
            }

            return Ok(activities);
        }

        
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FullActivityDto>> GetActivityById(Guid id, CancellationToken ct)
        {
            var activity = await Mediator.Send(new GetActivityDetails.Query{Id = id}, ct);

            if(activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        [HttpPost]
        public async Task<ActionResult<ReadActivityDto>> CreateActivity(CreateActivityDto dto, CancellationToken ct)
        {
            Logger.LogInformation("Create activity called for: {ActivityTitle}", dto.Title);
            var createdActivity = await Mediator.Send(new CreateActivity.Command{Activity = dto}, ct);
            Logger.LogInformation("Created activity with ID: {ActivityId}", createdActivity.Id);
            //return Created("Activity created", activity);
            return CreatedAtAction(nameof(GetActivityById), new { id = createdActivity.Id }, createdActivity);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditActivity(Guid id, FullActivityDto activity)
        {
            if (id != activity.Id)
            {
                return BadRequest("Route id does not match payload id.");    
            }

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
