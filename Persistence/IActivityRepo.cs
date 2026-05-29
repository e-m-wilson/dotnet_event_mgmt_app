using System;
using Domain;
namespace Persistence;

public interface IActivityRepo
{

    
    public Task<IEnumerable<Activity>> GetActivitiesAsync(CancellationToken ct);

    public Task<Activity> GetActivityAsync(Guid id, CancellationToken ct);

    public Task<Activity> CreateActivity(Activity activity, CancellationToken ct);

    public Task DeleteActivity(Guid id);

    public Task EditActivity(Activity activity);
}
