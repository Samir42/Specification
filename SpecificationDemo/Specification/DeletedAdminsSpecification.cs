using System.Linq.Expressions;
using Specification.Core.Entities;

namespace SpecificationDemo.Specification;

public class DeletedAdminsSpecification : Specification<User>
{
    public override Expression<Func<User, bool>> ToExpression()
    {
        return user => user.IsDeleted == true;
    }
}