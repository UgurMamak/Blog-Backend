using System;
//inserted
using Application.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Application.Persistence
{
  public  class BlogDbContext : DbContext
  {

    public BlogDbContext(DbContextOptions<BlogDbContext> options) :
      base(options)
    {
    }

    public  DbSet<User> Users { get; set; }

    public DbSet<Post> Posts { get; set; }

    public  DbSet<PostCategory> PostCategories { get; set; }

    public  DbSet<Category> Categories { get; set; }

    public  DbSet<Comment> Comments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

          /*
          e
            .HasOne(a => a.PostCategory)
            .WithMany(a => a.Posts)
            .HasForeignKey(a => a.PostCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
            */
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

          e.HasOne(a =>a.Post)
          .WithMany(a =>a.PostCategories)
          .HasForeignKey(a =>a.PostId)
          .OnDelete(DeleteBehavior.Cascade);

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
    }
  }
}
