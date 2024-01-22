using Specification.Core.Entities;
using SpecificationDemo.Infrastructure.Repositories;
using SpecificationDemo.Specifications;
using SpecificationDemo.Utils;
using Spectre.Console;

var specificationMap = new Dictionary<string, Specification<User>>
{
    { "All", Specification<User>.All },
    { "Available Admin Users", new AvailableAdminUsersSpecification() },
    { "Deleted Users", new DeletedUsersSpecification() },
    { "Locked Users", new LockedUsersSpecification() },
    { "Locked Or Disabled Users", new LockedUsersSpecification().Or(new DisabledUsersSpecification()) },
    { "Locked And Deleted Users", new LockedUsersSpecification().And(new DeletedUsersSpecification()) },
    { "Deleted Or Disabled Users", new DeletedUsersSpecification().Or(new DisabledUsersSpecification()) },
    { "Available and Adult Users", new AvailableAdminUsersSpecification().And(new AdultUsersSpecification()) },
    { "Available and Corporate Users", new AvailableAdminUsersSpecification().And(new CorporateUsersSpecification()) },
    { "Deleted and Corporate Users", new DeletedUsersSpecification().And(new CorporateUsersSpecification()) },
};

const bool RUN_CONTINUOSLY = true;

while (RUN_CONTINUOSLY)
{
    var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Which [green]users[/] you want to display?")
            .PageSize(15)
            .AddChoices(specificationMap.Keys));

    Console.Clear();

    if (specificationMap.TryGetValue(choice, out var spec))
    {
        PrintUsers(spec);
    }
}

void PrintUsers(Specification<User> specification)
{
    var users = new UserRepository().List(specification);

    var table = ConsoleUtils.GetTable();

    foreach (var user in users)
    {
        table.AddRow(ConsoleUtils.ToRow(user));
    }

    AnsiConsole.Write(table);
}