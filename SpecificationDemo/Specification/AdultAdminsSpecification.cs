using System.Linq.Expressions;
using Specification.Core.Entities;

namespace SpecificationDemo.Specification;

public class AdultAdminsSpecification : Specification<User>
{
    public override Expression<Func<User, bool>> ToExpression()
    {
        return user => user.Age >= 18;
    }
}