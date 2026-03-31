using HA_Ossooll.Data.Data;
using HA_Ossooll.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HA_Ossooll.Data.DTOs;

namespace HA_Ossooll.Data.Data;

public partial class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public const string DBConnectionString = ConnectionString.TestString;

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer(DBConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //_validator.Initialize(builder);
        //builder.Ignore<ConversionFactor>();
        builder.Entity<ApplicationUser>().ToTable("Users");
        builder.Entity<IdentityRole>().ToTable("Roles");
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
        builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
    }

    //public DbSet<Genre> Genres { get; set; }
    //public DbSet<Moviee> Movies { get; set; }

}