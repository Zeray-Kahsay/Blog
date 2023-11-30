using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog;
public class BlogContext : IdentityDbContext
      <AppUser, AppRole, int,
      IdentityUserClaim<int>,
      AppUserRole, 
      IdentityUserLogin<int>, 
      IdentityRoleClaim<int>, 
      IdentityUserToken<int>>  // sequence is important between AppUserRole and IdentityUserLogin !!!
{
     
  public BlogContext(DbContextOptions options) : base(options)
  {
    
  }

  
  public DbSet<Post> Posts { get; set; }
  public DbSet<Comment> Comments { get; set; }
  public DbSet<Likes> Likes { get; set; }
  public DbSet<Photo> Photos { get; set; }



   protected override void OnModelCreating (ModelBuilder builder)
  {
    base.OnModelCreating(builder);
    
    builder.Entity<AppRole>()
           .HasData(
              new AppRole { Id = 1, Name = "Memeber", NormalizedName = "MEMBER"},
              new AppRole { Id = 2, Name = "Admin", NormalizedName = "ADMIN"}
           );
    builder.Entity<Post>()
          .HasMany(c => c.Comments)
          .WithOne(p => p.Post)
          .OnDelete(DeleteBehavior.Cascade); //a comment belongs to a post, a post may have MANY comments
                                            // post deleted, its comments deleted
    
     builder.Entity<Post>()
          .HasMany(p => p.Likes)
          .WithOne(li => li.Post)
          .OnDelete(DeleteBehavior.Cascade); // a like belongs to a post, a post may have MANY Likes
                                            // post deleted, its likes deleted

    builder.Entity<Likes>()
        .HasKey(k => new { k.AppUserId, k.PostId } ); // doesn't have its own PK - Joint-table
    
      builder.Entity<AppUser>()
          .HasMany(a => a.UserLikes)
          .WithOne(ul => ul.AppUser)
          .OnDelete(DeleteBehavior.Restrict); // user may like posts, a like belongs to a user
                                              // user deleted, their likes remain

// MANY-to-MANY
    builder.Entity<AppUser>()
        .HasMany(ur => ur.UserRoles)
        .WithOne(u => u.User)
        .HasForeignKey(ur => ur.UserId)
        .IsRequired();

    builder.Entity<AppRole>()
        .HasMany(ur => ur.UserRoles)
        .WithOne(u => u.Role)
        .HasForeignKey(ur => ur.RoleId)
        .IsRequired();
  
  }

  
}

