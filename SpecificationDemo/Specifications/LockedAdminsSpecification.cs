using System.Linq.Expressions;
using Specification.Core.Entities;

namespace SpecificationDemo.Specifications;

public class LockedUsersSpecification : Specification<User>
{
    public override Expression<Func<User, bool>> ToExpression()
    {
        return user => user.IsLocked == true;
    }
}