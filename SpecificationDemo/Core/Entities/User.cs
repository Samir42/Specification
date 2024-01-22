using SpecificationDemo.Core.Entities;

namespace Specification.Core.Entities;

public class User : IEntity
{
    public int Id { get; set; }

    public required string Name { get; set; }
    
    public int Age { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public bool IsAdmin { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsLocked { get; set; }

    public bool IsDisabled { get; set; }
}