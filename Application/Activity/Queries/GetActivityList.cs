using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application;

public class GetActivityList
{
    
    public class Query : IRequest<IEnumerable<ReadActivityDto>> {}

    public class Handler(
        IActivityRepo repo,
        IMapper mapper
        ) : IRequestHandler<Query, IEnumerable<ReadActivityDto>>
    {

        public async Task<IEnumerable<ReadActivityDto>> Handle(
            Query request,
            CancellationToken ct
        )
        {
            var activities = await repo.GetActivitiesAsync(ct);
            return mapper.Map<IEnumerable<ReadActivityDto>>(activities);
        }
    }

}