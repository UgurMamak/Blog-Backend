using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Persistence.Congigurations
{
    public class LikePostConfiguration : IEntityTypeConfiguration<LikePost>
    {
        public void Configure(EntityTypeBuilder<LikePost> builder)
        {
            builder.ToTable("LikePost");
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.User)
                .WithMany(a => a.LikePosts)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Post)
                .WithMany(a => a.LikePosts)
                .HasForeignKey(a => a.PostId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}