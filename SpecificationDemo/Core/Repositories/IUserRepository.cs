using Specification.Core.Entities;
using SpecificationDemo.Specifications;

namespace SpecificationDemo.Core.Repositories;

public interface IUserRepository 
{
    IReadOnlyList<User> List(Specification<User> specification);
}