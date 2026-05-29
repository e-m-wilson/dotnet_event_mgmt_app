using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController<T> : ControllerBase
    {
        
        protected readonly ILogger<T> Logger;
        protected readonly IMediator Mediator;
        
        protected BaseApiController(ILogger<T> logger, IMediator mediator)
        {
            Logger = logger;
            Mediator = mediator;
        }
    }
}
