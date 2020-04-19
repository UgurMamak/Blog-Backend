using Application.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Persistence.SeedData
{
    public class CommentSeedData : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData(
                new Comment {Content="5g teknolojisi ile ilgili en iyi makale olmuş",
                ConfirmStatus=true,
                LikeStatus=false,
                UserId="eba5f437-e5ed-4d74-a68b-3303af51a7d5",
                PostId="34bb076e-36ca-4f6b-bb78-7949daeef2b1"
                 }
               
                );
        }
    }
}
