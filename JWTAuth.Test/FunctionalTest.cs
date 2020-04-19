using JWTAuth.Controllers;
using JWTAuth.Data;
using JWTAuth.Helpers;
using JWTAuth.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace JWTAuth.Test
{
    public class FunctionalTest
    {
        private LoginController controller;

        public FunctionalTest()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var loginHelper = new LoginHelper(config);
            controller = new LoginController(GetPhonebookContext(), loginHelper);
        }

        [Test]
        public void LoginTestUnauthorized()
        {
            //Act
            var a = controller.Login("Fail", "123") as UnauthorizedResult;

            //Assert
            Assert.AreEqual(a.StatusCode, 401);
        }

        [Test]
        public void LoginTestOk()
        {
            //Act
            var a = controller.Login("Succ", "123") as OkObjectResult;

            //Assert
            Assert.AreEqual(a.StatusCode, 200);
        }

        public PhonebookContext GetPhonebookContext()
        {
            var options = new DbContextOptionsBuilder<PhonebookContext>()
                            .UseInMemoryDatabase(databaseName: "InMemoryPhonebookDatabase")
                            .Options;
            var dbContext = new PhonebookContext(options);


            var userLogin = new UserLogin() { Username = "Succ", Password = "123", EmailAddress = "test@test.com"};
            dbContext.Add(userLogin);
            dbContext.SaveChanges();

            return dbContext;
        }

    }
}
