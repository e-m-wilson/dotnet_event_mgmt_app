using System;

namespace Application;

public class FullActivityDto
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public DateTimeOffset Date { get; set; }
    public required string Description { get; set; }
    public required string Category { get; set; }
    public bool IsCancelled { get; set; }
    public required string City { get; set; }
    public required string Venue { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
   
}
