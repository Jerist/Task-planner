using FluentAssertions;
using NUnit.Framework;
using TaskPlanner.DataAccess.Entities;
using TaskPlanner.Repository;

namespace TaskPlanner.UnitTests.Repository
{
    [TestFixture]
    [Category("Integration")]
    public class UserRepositoryTests: RepositoryTestsBaseClass
    {
        [Test]
        public void GetAllUsersTest()
        {
            using var context = DbContextFactory.CreateDbContext();

            var users = new User[]
            {
            new User()
            {
                Name="User1",
                Phone="User1",
                Email="User1",
                SecretHash="User1",
                ExternalId = Guid.NewGuid()
            },
            new User()
            {
                Name="User2",
                Phone="User2",
                Email="User2",
                SecretHash="User2",
                ExternalId = Guid.NewGuid()
            },
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            var repository = new Repository<User>(DbContextFactory);
            var actualUsers = repository.GetAll();
       
            actualUsers.Should().BeEquivalentTo(users);
        }

        [Test]
        public void GetAllUsersWithFilterTest()
        {
            using var context = DbContextFactory.CreateDbContext();

            var users = new User[]
           {
            new User()
            {
                Name="User1",
                Phone="User1",
                Email="User1",
                SecretHash="User1",
                ExternalId = Guid.NewGuid()
            },
            new User()
            {
                Name="User2",
                Phone="User2",
                Email="User2",
                SecretHash="User2",
                ExternalId = Guid.NewGuid()
            },
           };

            context.Users.AddRange(users);
            context.SaveChanges();

            var repository = new Repository<User>(DbContextFactory);
            var actualUsers = repository.GetAll(x => x.Name == "User1").ToArray();

            actualUsers.Should().BeEquivalentTo(users.Where(x => x.Name == "User1"));
        }

        [Test]
        public void SaveNewUserTest()
        {
            using var context = DbContextFactory.CreateDbContext();

            var user = new User()
            {
                Name = "User1",
                Phone = "User1",
                Email = "User1",
                SecretHash = "User1",
                ExternalId = Guid.NewGuid()
            };

            var repository = new Repository<User>(DbContextFactory);
            repository.Save(user);

            var actualUser = context.Users.SingleOrDefault();
            actualUser.Should().BeEquivalentTo(user, options => options.Excluding(x => x.Id)
                .Excluding(x => x.ModificationTime)
                .Excluding(x => x.CreationTime)
                .Excluding(x => x.ExternalId));
            actualUser.Id.Should().NotBe(default);
            actualUser.ModificationTime.Should().NotBe(default);
            actualUser.CreationTime.Should().NotBe(default);
            actualUser.ExternalId.Should().NotBe(Guid.Empty);
        }


        [Test]
        public void UpdateUserTest()
        {
            using var context = DbContextFactory.CreateDbContext();
            
            var user = new User()
            {
                Name = "User1",
                Phone = "User1",
                Email = "User1",
                SecretHash = "User1",
                ExternalId = Guid.NewGuid()
            };

            context.Users.Add(user);
            context.SaveChanges();

            user.Name = "new name";
            user.Email = "new email";
            var repository = new Repository<User>(DbContextFactory);
            repository.Save(user);

            var actualUser = context.Users.SingleOrDefault();
            actualUser.Should().BeEquivalentTo(user);
        }

        [Test]
        public void DeleteUserTest()
        {
            using var context = DbContextFactory.CreateDbContext();
            
            var user = new User()
            {
                Name = "User1",
                Phone = "User1",
                Email = "User1",
                SecretHash = "User1",
                ExternalId = Guid.NewGuid()
            };

            context.Users.Add(user);
            context.SaveChanges();


            var repository = new Repository<User>(DbContextFactory);
            repository.Delete(user);

            context.Users.Count().Should().Be(0);
        }

        [SetUp]
        public void SetUp()
        {
            CleanUp();
        }

        [TearDown]
        public void TearDown()
        {
            CleanUp();
        }

        public void CleanUp()
        {
            using (var context = DbContextFactory.CreateDbContext())
            {
                context.Users.RemoveRange(context.Users);
                context.SaveChanges();
            }
        }
    }
}
