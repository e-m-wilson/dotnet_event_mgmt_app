using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<Activity> Activities {get;set;}
    public required DbSet<ActivityTag> ActivityTags {get;set;}
    public required DbSet<Comment> Comments {get;set;}
    public required DbSet<Tag> Tags {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly);        
    }
}
