using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Tag
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    public List<ActivityTag> ActivityTags { get; set; } = [];
}
