using AutoMoq;
using BlogNetCore.Controllers;
using BlogNetCore.Models;
using BlogNetCore.Models.DataContracts.UserContracts;
using BlogNetCore.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;

namespace BlogNetCore.Tests
{
    [TestFixture]
    public class AuthControllerTests
    {

        [Test]
        public void RegisterAsyncAddUserAndReturnOk()
        {
            //Arrange
            var moker = new AutoMoqer();
            var user = new UserRegisterDto() { Email = "Ben@ben.com", Password = "Password@yandex.ru", PasswordConfirm = "Password@yandex.ru" };
            var mock = new UserManagerResponse();

            //var userService = moker.Create<IAuthService>();
            //var result = moker.GetMock<IAuthService>().Setup(x => x.RegisterUserAsync(user)).Returns(userManagerResonce);





            //Act 


            //Assert

            //bool res = Assert.IsInstanceOf<UserRegisterDto>();
            //Assert.AreEqual(newUser, result);
        }
    }
}




//var mock = new Mock<IAuthService>();
//var controller = new AuthController(mock.Object);
//var newUser = new UserRegisterDto() { Email = "Ben@ben.com", Password = "Password", PasswordConfirm = "Password" };


//var identityUser = new IdentityUser()
//{
//    Id = "a94a159f-1115-47f3-bfe0-ea2999a48894",
//    UserName = "Ben@ben.com",
//    NormalizedUserName = "Ben@ben.com",
//    Email = "Ben@ben.com",
//    NormalizedEmail = "Ben@ben.com",
//    EmailConfirmed = false,
//    PasswordHash = "AQAAAAEAACcQAAAAEJRWntubYuqU32fiefHeEbPvqU6H1EMnBZsf73c1Irp7J3A1/iTxtlA3uez6iZTJoQ==",
//    SecurityStamp = "JYWEEKJLJCX54JRU34TTM572XADA5IF6",
//    ConcurrencyStamp = "72ac8bbc-4f17-4787-8159-15dad57510a7",
//    PhoneNumber = null,
//    PhoneNumberConfirmed = false,
//    TwoFactorEnabled = false,
//    LockoutEnd = null,
//    LockoutEnabled = true,
//    AccessFailedCount = 0
//};