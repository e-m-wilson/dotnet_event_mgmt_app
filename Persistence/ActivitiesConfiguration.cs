using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence;

public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        // creating composite key for n-m relationship
        builder.HasCheckConstraint("CK_MIN_TITLE_LENGTH", "LEN(Title) > 4");
    }    
}