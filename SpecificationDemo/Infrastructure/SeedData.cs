using Specification.Core.Entities;

namespace SpecificationDemo.Infrastructure;

public static class SeedData
{
    static volatile bool Seeded = false;
    static object syncLock = new object();


    public static void EnsureUserSeedData(this UserDbContext userDbContext)
    {
        if (!Seeded && userDbContext.Users.Count() == 0)
        {
            lock (syncLock)
            {
                if (!Seeded)
                {
                    var users = GetUsers();

                    userDbContext.Users.AddRange(users);
                    userDbContext.SaveChanges();

                    Seeded = true;
                }
            }
        }
    }

    private static List<User> GetUsers()
    {
        return new List<User> {
            new User
            {
                Id = 1,
                Email = "test1@corporate.com",
                Name = "Test 1",
                Age = 17,
                IsDeleted = false,
                IsDisabled = false,
                IsLocked = false,
                Password = "123456",
                IsAdmin = true,
            },
            new User
            {
                Id = 2,
                Email = "test2@corporate.com",
                Name = "Test 2",
                Age = 25,
                IsDeleted = false,
                IsDisabled = false,
                IsLocked = false,
                Password = "654321",
                IsAdmin = true,
            },
            new User
            {
                Id = 3,
                Email = "test3@gmail.com",
                Name = "Test 3",
                Age = 22,
                IsDeleted = false,
                IsDisabled = true,
                IsLocked = true,
                Password = "password123",
                IsAdmin = false,
            },
            new User
            {
                Id = 4,
                Email = "test4@gmail.com",
                Name = "Test 4",
                Age = 30,
                IsDeleted = true,
                IsDisabled = true,
                IsLocked = false,
                Password = "pass4321",
                IsAdmin = false,
            },
            new User
            {
                Id = 5,
                Email = "test5@gmail.com",
                Name = "Test 5",
                Age = 28,
                IsDeleted = true,
                IsDisabled = true,
                IsLocked = false,
                Password = "qwerty",
                IsAdmin = true,
            },
            new User
            {
                Id = 6,
                Email = "test6@gmail.com",
                Name = "Test 6",
                Age = 35,
                IsDeleted = true,
                IsDisabled = true,
                IsLocked = true,
                Password = "passpass",
                IsAdmin = false,
            },
            new User
            {
                Id = 7,
                Email = "test7@gmail.com",
                Name = "Test 7",
                Age = 23,
                IsDeleted = false,
                IsDisabled = false,
                IsLocked = false,
                Password = "pass1234",
                IsAdmin = false,
            },
            new User
            {
                Id = 8,
                Email = "test8@gmail.com",
                Name = "Test 8",
                Age = 26,
                IsDeleted = true,
                IsDisabled = false,
                IsLocked = true,
                Password = "passpass",
                IsAdmin = false,
            },
            new User
            {
                Id = 9,
                Email = "test9@gmail.com",
                Name = "Test 9",
                Age = 32,
                IsDeleted = true,
                IsDisabled = false,
                IsLocked = true,
                Password = "password",
                IsAdmin = true,
            },
            new User
            {
                Id = 10,
                Email = "test10@gmail.com",
                Name = "Test 10",
                Age = 21,
                IsDeleted = true,
                IsDisabled = true,
                IsLocked = false,
                Password = "pass456",
                IsAdmin = true,
            }
        };
    }
}