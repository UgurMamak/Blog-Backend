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
                    Id= "374aef84-52f9-4873-855d-6ab420ba675e"
                },
                new Post { }
                );
        }
    }
}
