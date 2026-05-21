using System;

namespace Application;

public class ReadCommentDto
{
    public Guid Id {get;set;}
    public Guid ActivityId {get;set;}

    public string UserComment {get;set;}
}
