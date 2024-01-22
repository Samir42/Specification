using System.Linq.Expressions;
using Specification.Core.Entities;

namespace SpecificationDemo.Specification;

public class DisabledAdminsSpecification : Specification<User>
{
    public override Expression<Func<User, bool>> ToExpression()
    {
        return user => user.IsDisabled == true;
    }
}