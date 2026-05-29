using AutoMapper;
using Domain;
using MediatR;
using Persistence;


namespace Application;

public class CreateActivity
{
    

    public class Command : IRequest<ReadActivityDto>
    {
        public required CreateActivityDto Activity {get;set;}
    }

    public class Handler(
        IActivityRepo repo,
        IMapper mapper
    ) : IRequestHandler<Command, ReadActivityDto>
    {
        
        public async Task<ReadActivityDto> Handle(
            Command request, 
            CancellationToken ct
        )
        {
            var mappedActivity = mapper.Map<Activity>(request.Activity);
            var activity = await repo.CreateActivity(mappedActivity, ct);
            return mapper.Map<ReadActivityDto>(activity);
        }
    }
}