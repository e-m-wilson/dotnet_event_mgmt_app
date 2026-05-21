using System;

namespace Application;

public class CreateActivityDto
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Category { get; set; }
    public required string City { get; set; }
    public required string Venue { get; set; }
    public required string Latitude { get; set; }
    public required string Longitude { get; set; }
}
