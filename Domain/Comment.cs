using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Comment
{
    public Guid Id {get; set;} = Guid.NewGuid();

    [ForeignKey("Activity")]
    public Guid ActivityId {get;set;}
  
    public Activity? Activity {get;set;}
    [MinLength(4)]
    [MaxLength(255)]
    [Required]
    public required string UserComment {get;set;}

}
