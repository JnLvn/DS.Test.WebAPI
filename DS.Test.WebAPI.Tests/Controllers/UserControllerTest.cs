using DS.Test.WebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DS.Test.WebAPI.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void GetAllUsers()
        {
            // Arrange
            UserController controller = new UserController();

            // Act
            IEnumerable<User> result = controller.GetAllUsers();

            User jl;
            User jb;

            using (UsersEntities users = new UsersEntities())
            {
                jl = users.Users.Where(u => u.Id == 1).FirstOrDefault<User>();
                jb = users.Users.Where(u => u.Id == 2).FirstOrDefault<User>();
            }

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(jl, result.ElementAt(0));
            Assert.AreEqual(jb, result.ElementAt(1));
        }

        [TestMethod]
        public void GetUser()
        {
            // Arrange
            UserController controller = new UserController();

            // Act
            User result = controller.GetUser(1);

            User jl;

            using (UsersEntities users = new UsersEntities())
            {
                jl = users.Users.Where(u => u.Id == 1).FirstOrDefault<User>();
            }

            // Assert
            Assert.AreEqual(jl, result);
        }

        [TestMethod]
        public void CreateUser()
        {
            // Arrange
            UserController controller = new UserController();

            // Act
            controller.CreateUser(99, "Test");
        }

        [TestMethod]
        public void UpdateUser()
        {
            // Arrange
            UserController controller = new UserController();

            // Act
            controller.UpdateUser(99, "Test 1");
        }

        [TestMethod]
        public void DeleteUser()
        {
            // Arrange
            UserController controller = new UserController();

            // Act
            controller.DeleteUser(99);
        }
    }
}
