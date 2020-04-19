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
                new LikePost {PostId="34bb076e-36ca-4f6b-bb78-7949daeef2b1",
                UserId="6a818bb9-8bd3-421a-8fd8-7c0d18df8094",
                LikeStatus=false }
                
                );
        }
    }
}
