using AutoMapper;
using MediatR;
using Persistence;

namespace Application;

public class GetActivityDetails
{
    

    public class Query : IRequest<ReadActivityDto>
    {
        public required Guid Id {get;set;}
    }

    public class Handler(
        IActivityRepo repo,
        IMapper mapper
    ) : IRequestHandler<Query, ReadActivityDto>
    {
        
        public async Task<ReadActivityDto> Handle(Query request, CancellationToken ct)
        {
            var activity = await repo.GetActivityAsync(request.Id, ct);     
            return mapper.Map<ReadActivityDto>(activity);       
        }
    }
}