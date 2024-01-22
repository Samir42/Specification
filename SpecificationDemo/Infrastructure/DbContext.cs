using Microsoft.EntityFrameworkCore;
using Specification.Core.Entities;

namespace SpecificationDemo.Infrastructure;

public class UserDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> options)
    : base(options)
    {
        this.EnsureUserSeedData();
    }
}