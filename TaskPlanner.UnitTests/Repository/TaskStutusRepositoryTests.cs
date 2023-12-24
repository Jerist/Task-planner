using FluentAssertions;
using NUnit.Framework;
using TaskPlanner.Repository;

namespace TaskPlanner.UnitTests.Repository
{
    [TestFixture]
    [Category("Integration")]
    public class TaskStutusRepositoryTests: RepositoryTestsBaseClass
    {
        [Test]
        public void GetAllTaskStatusesTEst()
        {
            using var context = DbContextFactory.CreateDbContext();

            var statuses = new DataAccess.Entities.TaskStatus[]
            {
            new DataAccess.Entities.TaskStatus()
            {
                Status="В процессе",
                ExternalId = Guid.NewGuid()
            },
            new DataAccess.Entities.TaskStatus()
            {
                Status="Задача выполнена",
                ExternalId = Guid.NewGuid()
            },
            };
            context.TaskStatuses.AddRange(statuses);
            context.SaveChanges();

            var repository = new Repository<DataAccess.Entities.TaskStatus>(DbContextFactory);
            var actualStatuses = repository.GetAll();
            
            actualStatuses.Should().BeEquivalentTo(statuses);
        }


        [Test]
        public void GetAllStatusesWithFilterTest()
        {
            using var context = DbContextFactory.CreateDbContext();

            var statuses = new DataAccess.Entities.TaskStatus[]
            {
            new DataAccess.Entities.TaskStatus()
            {
                Status="В процессе",
                ExternalId = Guid.NewGuid()
            },
            new DataAccess.Entities.TaskStatus()
            {
                Status="Задача выполнена",
                ExternalId = Guid.NewGuid()
            },
            };
            context.TaskStatuses.AddRange(statuses);
            context.SaveChanges();

            var repository = new Repository<DataAccess.Entities.TaskStatus>(DbContextFactory);
            var actualStatuses = repository.GetAll(x => x.Status == "В процессе");

            actualStatuses.Should().BeEquivalentTo(statuses.Where(x => x.Status == "В процессе"));
        }

        [Test]
        public void SaveNewStatusTest()
        {
            using var context = DbContextFactory.CreateDbContext();


            var status = new DataAccess.Entities.TaskStatus()
            {
                Status="В процессе",
                ExternalId = Guid.NewGuid()
            };
            var repository = new Repository<DataAccess.Entities.TaskStatus>(DbContextFactory);
            repository.Save(status);

            var actualStatus = context.TaskStatuses.SingleOrDefault();
            actualStatus.Should().BeEquivalentTo(status, options => options.Excluding(x => x.Id)
                .Excluding(x => x.ModificationTime)
                .Excluding(x => x.CreationTime)
                .Excluding(x => x.ExternalId));
            actualStatus.Id.Should().NotBe(default);
            actualStatus.ModificationTime.Should().NotBe(default);
            actualStatus.CreationTime.Should().NotBe(default);
            actualStatus.ExternalId.Should().NotBe(Guid.Empty);
        }


        [Test]
        public void UpdateStatusTest()
        {
            using var context = DbContextFactory.CreateDbContext();

            var status = new DataAccess.Entities.TaskStatus()
            {
                Status = "В процессе",
                ExternalId = Guid.NewGuid()
            };
            context.TaskStatuses.Add(status);
            context.SaveChanges();


            status.Status = "Завершён";
            var repository = new Repository<DataAccess.Entities.TaskStatus>(DbContextFactory);
            repository.Save(status);

            var actualStatus = context.TaskStatuses.SingleOrDefault();
            actualStatus.Should().BeEquivalentTo(status);
        }

        [Test]
        public void DeleteStatusTest()
        {
            using var context = DbContextFactory.CreateDbContext();

            var status = new DataAccess.Entities.TaskStatus()
            {
                Status = "В процессе",
                ExternalId = Guid.NewGuid()
            };
            context.TaskStatuses.Add(status);
            context.SaveChanges();

            var repository = new Repository<DataAccess.Entities.TaskStatus>(DbContextFactory);
            repository.Delete(status);

            context.TaskStatuses.Count().Should().Be(0);
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
                context.TaskStatuses.RemoveRange(context.TaskStatuses);
                context.SaveChanges();
            }
        }

    }
}
