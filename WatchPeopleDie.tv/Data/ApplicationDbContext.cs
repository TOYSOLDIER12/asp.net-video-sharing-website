using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WatchPeopleDie.tv.Models;

namespace WatchPeopleDie.tv.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Video>? Video { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Video>()
            .HasKey(v => v.Id);
        modelBuilder.Entity<Video>()
            .HasOne<User>(v => v.poster)
            .WithMany(u => u.posted)
            .HasForeignKey(v => v.UserId);
    }
}