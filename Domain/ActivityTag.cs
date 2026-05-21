using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class ActivityTag
{
    [ForeignKey(nameof(Activity))]
    public Guid ActivityId { get; set; }
    [Required]
    public required Activity Activity { get; set; }

    [ForeignKey(nameof(Tag))]
    public Guid TagId { get; set; }

    [Required]
    public required Tag Tag { get; set; }
}
