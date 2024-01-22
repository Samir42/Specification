using Specification.Core.Entities;
using Spectre.Console;

namespace SpecificationDemo.Utils;

public static class ConsoleUtils
{
    public static string[] ToRow(User user)
    {
        return new string[] {
        user.Id.ToString(),
        user.Name,
        user.Email,
        user.Password,
        user.Age.ToString(),
        user.IsAdmin.ToString(),
        user.IsDeleted.ToString(),
        user.IsLocked.ToString(),
        user.IsDisabled.ToString()
    };
    }

    public static Table GetTable()
    {
        var table = new Table().Centered();

        table.AddColumn("ID");
        table.AddColumn("Name");
        table.AddColumn("Email");
        table.AddColumn("Password");
        table.AddColumn("Age");
        table.AddColumn("IsAdmin");
        table.AddColumn("IsDeleted");
        table.AddColumn("IsLocked");
        table.AddColumn("IsDisabled");

        return table;
    }
}