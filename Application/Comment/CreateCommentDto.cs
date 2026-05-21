using System;

namespace Application;

public class CreateCommentDto
{

    public Guid ActivityId {get;set;}

    public string UserComment {get;set;}
}
