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
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims  { get; set; }



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

            modelBuilder.ApplyConfiguration(new OperationClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserOperationClaimConfiguration());



           // modelBuilder.ApplyConfiguration(new UserSeedData());
           // modelBuilder.ApplyConfiguration(new CategorySeedData());
            //modelBuilder.ApplyConfiguration(new PostSeedData());
            //modelBuilder.ApplyConfiguration(new PostCategorySeedData());
            // modelBuilder.ApplyConfiguration(new CommentSeedData());
            ///modelBuilder.ApplyConfiguration(new LikePostSeedData());
       
        }
    }
}
