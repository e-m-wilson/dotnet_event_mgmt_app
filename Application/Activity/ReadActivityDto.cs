using System;

namespace Application;

public class ReadActivityDto
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Category { get; set; }
    
}
