using System;
using AutoMapper;
using Domain;
using Persistence;

namespace Application;

public class ActivityService_Impl : IActivityService
{

    private readonly IActivityRepo _repo;
    private readonly IMapper _mapper;

    public ActivityService_Impl(IActivityRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReadActivityDto>> GetActivitiesAsync()
    {

        var activities = await _repo.GetActivitiesAsync();

        var mappedActivities = activities
            .Select(a => _mapper.Map<ReadActivityDto>(a))
            .ToList();


        return mappedActivities;
    }

    public async Task<FullActivityDto?> GetActivityAsync(Guid id)
    {

        var activity = await _repo.GetActivityAsync(id);

        if (activity == null)
            return null;

        var mappedActivity = _mapper.Map<FullActivityDto>(activity);

        return mappedActivity;
    }

    public async Task<ReadActivityDto> CreateActivity(CreateActivityDto dto)
    {
        var entity = _mapper.Map<Activity>(dto);
        var created = await _repo.CreateActivity(entity);
        return _mapper.Map<ReadActivityDto>(created);
    }

    public async Task DeleteActivity(Guid id)
    {
        await _repo.DeleteActivity(id);
    }

    public async Task EditActivity(FullActivityDto activity)
    {
        var a = _mapper.Map<Activity>(activity);
        await _repo.EditActivity(a);
    }
}
