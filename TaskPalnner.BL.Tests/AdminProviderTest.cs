using Moq;
using NUnit.Framework;
using System.Linq.Expressions;
using TaskPalnner.BL.Tests.Mapper;
using TaskPlanner.BL.Admins;
using TaskPlanner.DataAccess.Entities;
using TaskPlanner.Repository;

namespace TaskPalnner.BL.Tests
{
    [TestFixture]
    public class AdminProviderTest
    {
        [Test]
        public void TestGetAllAdmins()
        {
            Expression expression = null;
            Mock<IRepository<Admin>> adminRepository = new Mock<IRepository<Admin>>();
            adminRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<Admin, bool>>>()))
                .Callback((Expression<Func<Admin, bool>> x) => { expression = x; });
            var adminProvider = new AdminProvider(adminRepository.Object, MapperHelper.Mapper);
            var admin = adminProvider.GetAdmins();

            adminRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<Admin, bool>>>()), Times.Exactly(1));
        }
    }
}
