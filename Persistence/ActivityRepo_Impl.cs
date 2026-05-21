using System;
using Domain;
using Microsoft.EntityFrameworkCore;
namespace Persistence;

public class ActivityRepo_Impl : IActivityRepo
{

    private readonly AppDbContext _context;

    public ActivityRepo_Impl(AppDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Activity>> GetActivitiesAsync()
    {
        var activities = await _context.Activities
        .AsNoTracking()
        .ToListAsync();
        return activities;
    }

    public async Task<Activity> GetActivityAsync(Guid id)
    {
        
        var activity = await _context.Activities.FindAsync(id);
        return activity!;
    }

    public async Task<Activity> CreateActivity(Activity activity)
    {
        _context.Activities.Add(activity);
        await _context.SaveChangesAsync();
        return activity;
    }

    public async Task DeleteActivity(Guid id)
    {
        await _context.Activities.Where(a => a.Id == id).ExecuteDeleteAsync();
    }

    public async Task EditActivity(Activity activity)
    {
        var a = await _context.Activities.FindAsync(activity.Id);
        a.Category = activity.Category;
        a.City = activity.City;
        a.Date = activity.Date;
        a.Title = activity.Title;
        a.Description = activity.Description;
        a.IsCancelled = activity.IsCancelled;
        a.Venue = activity.Venue;
        a.Latitude = activity.Latitude;
        a.Longitude = activity.Longitude;
        await _context.SaveChangesAsync();
    }
}
