using System;
using System.Security.Authentication;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence;

public class DbInitializer
{

    public static async Task SeedData(AppDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {


      var roles = new List<string>{"Admin", "User"};
      foreach(var role in roles)
      {
        if(!await roleManager.RoleExistsAsync(role)){
            await roleManager.CreateAsync(new IdentityRole(role));
        }
      }

      if(!userManager.Users.Any())
    {
      var users = new List<User>
      {
        new User{DisplayName = "Bob", UserName = "bob@test.com", Email = "bob@test.com"},
        new User{DisplayName = "Tom", UserName = "tom@test.com", Email = "tom@test.com"},
        new User{DisplayName = "Jane", UserName = "jane@test.com", Email = "jane@test.com"}
      };

      foreach(var user in users)
      {
        await userManager.CreateAsync(user, "Pa$$w0rd");
        if(!(user.UserName == "bob@test.com"))
        {
          await userManager.AddToRoleAsync(user, "User");
        } else
        {
          await userManager.AddToRoleAsync(user, "Admin");
        }
      }
    }



        
        if (context.Activities.Any()) return;

        var random = new Random();
        var activities = new List<Activity>();
        var categories = new List<string>
        {
          "Music", "Sports", "Food", "Tech", "Art"  
        };
        var cities = new List<string>
        {
          "Little Rock", "Cabot", "Conway", "Jacksonville", "Memphis"  
        };
        var venues = new List<string>
        {
          "Main Hall", "City Park", "Conference Center", "Downtown Arena"  
        };

        for(int i = 0; i < 20; i++)
        {
            
            var activity = new Activity
            {
               Title = $"Test Activity {i + 1}",
               Description = $"Test is test activity number {i + 1}",
               Date =  DateTimeOffset.Now.AddDays(random.Next(-10, 30)), // inclusive,exclusive; so -10 to 29 days
               Category = categories[random.Next(categories.Count)],
               IsCancelled = random.NextDouble() < 0.2,
               City = cities[random.Next(cities.Count)],
               Venue = venues[random.Next(venues.Count)],

               Latitude = (random.NextDouble() * 180 - 90).ToString(),
               Longitude = (random.NextDouble() * 360 - 180).ToString()
            };
            activities.Add(activity);
        }

        context.Activities.AddRange(activities);
        await context.SaveChangesAsync();
    }
}
