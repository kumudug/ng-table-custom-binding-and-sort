namespace ng_table_custom.service.user.tests
{
    using async.mock;
    using data.Context;
    using data.Entities;
    using data.Repository;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    [TestClass]
    public class UserServiceTests
    {
        private readonly UserService _userService;
        private IQueryable<User> userList;

        public UserServiceTests()
        {
            userList = new List<User>
            {
                new User {Id=1, CreatedBy="", ModifiedBy="", CreatedDate= DateTime.Now, ModifiedDate=DateTime.Now, FirstName="Manuel", LastName="French", DOB=DateTime.Now },
                new User {Id=2, CreatedBy="", ModifiedBy="", CreatedDate= DateTime.Now, ModifiedDate=DateTime.Now, FirstName="Patty", LastName="Palmer", DOB=DateTime.Now },
                new User {Id=3, CreatedBy="", ModifiedBy="", CreatedDate= DateTime.Now, ModifiedDate=DateTime.Now, FirstName="Sheldon", LastName="Holmes", DOB=DateTime.Now },
                new User {Id=4, CreatedBy="", ModifiedBy="", CreatedDate= DateTime.Now, ModifiedDate=DateTime.Now, FirstName="Chester", LastName="May", DOB=DateTime.Now },
                new User {Id=5, CreatedBy="", ModifiedBy="", CreatedDate= DateTime.Now, ModifiedDate=DateTime.Now, FirstName="Lorena", LastName="Ray", DOB=DateTime.Now }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();

            mockSet = mockSet.SetupLinq(userList);
            mockSet = mockSet.SetupFind((keyValues, entity) => entity.Id == (int)keyValues.Single());

            var mockContext = new Mock<NgTableContext>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);
            mockContext.Setup(c => c.Set<User>()).Returns(mockSet.Object);

            var userRepo = new Mock<UserRepository>(mockContext.Object) { CallBase = true };
            _userService = new UserService(userRepo.Object);
        }

        [TestMethod]
        public void GetUserById()
        {
            var result = _userService.GetUserById(1).Result;
            var actual = userList.ToList()[0];
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, actual.Id);
            Assert.AreEqual(result.FirstName, actual.FirstName);
        }

        [TestMethod]
        public void GetAllUsers()
        {
            var result = _userService.GetAllUsers().Result;
            var actual = userList.ToList();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, actual.Count);
        }
    }
}
