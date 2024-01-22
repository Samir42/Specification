using Specification.Core.Entities;
using SpecificationDemo.Infrastructure.Repositories;
using SpecificationDemo.Specification;
using SpecificationDemo.Utils;
using Spectre.Console;

var specificationMap = new Dictionary<string, Specification<User>>
{
    { "All", Specification<User>.All },
    { "Available Admins", new AvailableAdminsSpecification() },
    { "Deleted Admins", new DeletedAdminsSpecification() },
    { "Locked Admins", new LockedAdminsSpecification() },
    { "Locked Or Disabled Admins", new LockedAdminsSpecification().Or(new DisabledAdminsSpecification()) },
    { "Locked And Deleted Admins", new LockedAdminsSpecification().And(new DeletedAdminsSpecification()) },
    { "Deleted Or Disabled Admins", new DeletedAdminsSpecification().Or(new DisabledAdminsSpecification()) },
    { "Available and Adult Admins", new AvailableAdminsSpecification().And(new AdultAdminsSpecification()) },
    { "Available and Corporate Admins", new AvailableAdminsSpecification().And(new CorporateAdminsSpecification()) },
    { "Deleted and Corporate Admins", new DeletedAdminsSpecification().And(new CorporateAdminsSpecification()) },
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