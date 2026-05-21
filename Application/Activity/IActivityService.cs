using System;
using Domain;

namespace Application;

public interface IActivityService
{

    public Task<IEnumerable<ReadActivityDto>> GetActivitiesAsync();

    public Task<FullActivityDto> GetActivityAsync(Guid id);

    public Task<ReadActivityDto> CreateActivity(CreateActivityDto dto);

    public Task DeleteActivity(Guid id);

    public Task EditActivity(FullActivityDto activity);
}
