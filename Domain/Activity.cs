using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("Activities")]
public class Activity
{
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    [MaxLength(55)]
    public required string Title { get; set; }
    public DateTimeOffset Date { get; set; }
    [Column("Description", TypeName = "nvarchar(255)")]
    public required string Description { get; set; }
    public required string Category { get; set; }
    public bool IsCancelled { get; set; }
    public required string City { get; set; }
    public required string Venue { get; set; }
    public required string Latitude { get; set; }
    public required string Longitude { get; set; }
    public List<Comment> Comments {get;set;} = [];
    public List<ActivityTag> ActivityTags { get; set; } = [];

}