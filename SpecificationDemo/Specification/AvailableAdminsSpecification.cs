using System.Linq.Expressions;
using Specification.Core.Entities;

namespace SpecificationDemo.Specification;

public class AvailableAdminsSpecification : Specification<User>
{
    public override Expression<Func<User, bool>> ToExpression()
    {
        return user => user.IsAdmin == true &&
                       user.IsLocked == false &&
                       user.IsDisabled == false &&
                       user.IsDeleted == false;
    }
}