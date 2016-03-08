namespace ng_table_custom.web.api.tests
{
    using App_Start;
    using Controllers;
    using data.Entities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using service.user;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Results;
    using viewmodel;

    [TestClass]
    public class UserControllerTests
    {
        private readonly UserController _userController;
        private readonly List<User> _userList;

        public UserControllerTests()
        {
            var _userService = new Mock<IUserService>();

            _userList = new List<User>
            {
                new User {Id=1, CreatedBy="", ModifiedBy="", CreatedDate= DateTime.Now, ModifiedDate=DateTime.Now, FirstName="Manuel", LastName="French", DOB=DateTime.Now },
                new User {Id=2, CreatedBy="", ModifiedBy="", CreatedDate= DateTime.Now, ModifiedDate=DateTime.Now, FirstName="Patty", LastName="Palmer", DOB=DateTime.Now },
                new User {Id=3, CreatedBy="", ModifiedBy="", CreatedDate= DateTime.Now, ModifiedDate=DateTime.Now, FirstName="Sheldon", LastName="Holmes", DOB=DateTime.Now },
                new User {Id=4, CreatedBy="", ModifiedBy="", CreatedDate= DateTime.Now, ModifiedDate=DateTime.Now, FirstName="Chester", LastName="May", DOB=DateTime.Now },
                new User {Id=5, CreatedBy="", ModifiedBy="", CreatedDate= DateTime.Now, ModifiedDate=DateTime.Now, FirstName="Lorena", LastName="Ray", DOB=DateTime.Now }
            };

            _userService.Setup(s => s.GetUserById(1)).Returns(Task.FromResult(_userList[0]));
            _userService.Setup(s => s.GetAllUsers()).Returns(Task.FromResult(_userList));

            _userController = new UserController(_userService.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            AutomapperBootstrap.Register();
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            var result = _userController.GetUserById(1).Result;
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<UserVM>));
        }

        [TestMethod]
        public void GetAllUsersTest()
        {
            var result = _userController.GetUsers().Result;
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<List<UserVM>>));
        }
    }
}
