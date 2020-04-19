using Application.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.SeedData
{ 
    public class PostSeedData : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(
                new Post { Title="5G Teknolojisinin getirdiği yenilikler",Content="5G teknoloji ile Frekans bandı dha verimli kullanılmaya başlandı.",
                    UserId= "6a818bb9-8bd3-421a-8fd8-7c0d18df8094"
                },
                new Post { Title="Spor yapmanın faydaları",Content="metabolizmayı güçlendirir. Daha dinç ve zinde olurusunuz.",
                    UserId= "6a818bb9-8bd3-421a-8fd8-7c0d18df8094"
                }
                );
        }
    }
}
