using System;
using Domain;
namespace Persistence;

public interface IActivityRepo
{

    
    public Task<IEnumerable<Activity>> GetActivitiesAsync();

    public Task<Activity> GetActivityAsync(Guid id);

    public Task<Activity> CreateActivity(Activity activity);

    public Task DeleteActivity(Guid id);

    public Task EditActivity(Activity activity);
}
