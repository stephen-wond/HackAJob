using JWTAuth.Helpers;
using JWTAuth.Model;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace JWTAuth.Test
{
    public class LoginUnitTest
    {
        [Test]
        public void GenerateWebToken()
        {
            //Arrange
            var user = new UserLogin() { Username = "Steve", Password = "123", EmailAddress = "Steve@Steve.com" };
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            ILoginHelper loginHelper = new LoginHelper(config);

            //Act
            var token = loginHelper.GenerateJSONWebToken(user);

            //Assert
            Assert.IsTrue(token.Length > 0);
        }
    }
}