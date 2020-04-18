using System;
//inserted
using Application.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Application.Persistence.Congigurations;
using Application.Persistence.SeedData;

namespace Application.Persistence
{
    public class BlogDbContext : DbContext
    {
        // yeni kapatt�n hata oldu�u i�in
        /*
       public BlogDbContext(DbContextOptions<BlogDbContext> options) :
         base(options)
       {
       }
        */

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostCategory> PostCategories { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<LikePost> LikePosts { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BlogDB;User ID=sa;Password=123456;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new LikePostConfiguration());
            modelBuilder.ApplyConfiguration(new PostCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            //modelBuilder.ApplyConfiguration(new UserSeedData());
            //modelBuilder.ApplyConfiguration(new CategorySeedData());
            modelBuilder.ApplyConfiguration(new PostSeedData());
           /* modelBuilder.ApplyConfiguration(new PostCategorySeedData());
            modelBuilder.ApplyConfiguration(new CommentSeedData());
            modelBuilder.ApplyConfiguration(new LikePostSeedData());*/




            /*
              modelBuilder
                .Entity<User>(e =>
                {
                    e.ToTable("User");
                    e.HasKey(a => a.Id);
                });

              modelBuilder
                .Entity<Category>(e =>
                {
                    e.ToTable("Category");
                    e.HasKey(a => a.Id);
                });

              modelBuilder
                .Entity<Post>(e =>
                {
                    e.ToTable("Post");
                    e.HasKey(a => a.Id);

                    e
                .HasOne(a => a.User)
                .WithMany(a => a.Posts)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);


                    e.HasMany(a => a.PostCategories)
              .WithOne(a => a.Post)
              .HasForeignKey(a => a.PostId)
              .OnDelete(DeleteBehavior.Cascade);


                });

              modelBuilder
                .Entity<PostCategory>(e =>
                {
                    e.ToTable("PostCategory");
                    e.HasKey(a => a.Id);

                    e
                .HasOne(a => a.Category)
                .WithMany(a => a.PostCategories)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);


                             // e.HasOne(a =>a.Post)
                             // .WithMany(a =>a.PostCategories)
                             // .HasForeignKey(a =>a.PostId)
                              //.OnDelete(DeleteBehavior.Cascade);

                });


              modelBuilder
                .Entity<Comment>(e =>
                {
                    e.ToTable("Comment");
                    e.HasKey(a => a.Id);

                    e
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                    e
                .HasOne(a => a.Post)
                .WithMany(a => a.Comments)
                .HasForeignKey(a => a.PostId)
                .OnDelete(DeleteBehavior.Restrict);
                });
                */
        }
    }
}
