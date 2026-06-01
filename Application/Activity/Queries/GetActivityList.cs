using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application;

public class GetActivityList
{
    
    public class Query : IRequest<IEnumerable<FullActivityDto>> {}

    public class Handler(
        IActivityRepo repo,
        IMapper mapper
        ) : IRequestHandler<Query, IEnumerable<FullActivityDto>>
    {

        public async Task<IEnumerable<FullActivityDto>> Handle(
            Query request,
            CancellationToken ct
        )
        {
            var activities = await repo.GetActivitiesAsync(ct);
            return mapper.Map<IEnumerable<FullActivityDto>>(activities);
        }
    }

}