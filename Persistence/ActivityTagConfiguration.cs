using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence;

public class ActivityTagConfiguration : IEntityTypeConfiguration<ActivityTag>
{
    public void Configure(EntityTypeBuilder<ActivityTag> builder)
    {
        // creating composite key for n-m relationship
        builder.HasKey(at => new { at.ActivityId, at.TagId });
    }    
}