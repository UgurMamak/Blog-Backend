using Application.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.SeedData
{
    public class LikePostSeedData : IEntityTypeConfiguration<LikePost>
    {
        public void Configure(EntityTypeBuilder<LikePost> builder)
        {
            builder.HasData(
                new LikePost { },
                new LikePost { }
                );
        }
    }
}
