using Application.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.SeedData
{
    public class PostCategorySeedData : IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            builder.HasData(
                new PostCategory {PostId="d1013284-4e87-47c6-b28f-47ece4ba9888",CategoryId="6ab2c130-b07f-4d76-86dd-d9f1d89fac81" },
                new PostCategory {PostId="34bb076e-36ca-4f6b-bb78-7949daeef2b1",CategoryId="68a8cbe3-847f-4cb9-9f40-f89dabaa308c" }
                );
        }
    }
}
