using Microsoft.EntityFrameworkCore;
using Specification.Core.Entities;
using SpecificationDemo.Core.Repositories;
using SpecificationDemo.Specifications;

namespace SpecificationDemo.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _userDbContext;

    public UserRepository()
    {
        var options = new DbContextOptionsBuilder<UserDbContext>()
                 .UseInMemoryDatabase("UserDb")
                 .Options;

        _userDbContext = new UserDbContext(options);
    }

    public IReadOnlyList<User> List(Specification<User> specification)
    {
        return _userDbContext.Users.Where(specification.ToExpression()).ToList();
    }
}
