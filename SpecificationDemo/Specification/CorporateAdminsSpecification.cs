using System.Linq.Expressions;
using Specification.Core.Entities;

namespace SpecificationDemo.Specification;

public class CorporateAdminsSpecification : Specification<User>
{
    public override Expression<Func<User, bool>> ToExpression()
    {
        return user => user.Email.EndsWith("corporate.com");
    }
}