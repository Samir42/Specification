using Specification.Core.Entities;
using SpecificationDemo.Specification;

namespace SpecificationDemo.Core.Repositories;

public interface IUserRepository 
{
    IReadOnlyList<User> List(Specification<User> specification);
}