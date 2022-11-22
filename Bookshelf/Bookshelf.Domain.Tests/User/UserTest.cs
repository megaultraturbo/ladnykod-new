using System;
using Bookshelf.Domain.DomainExceptions;
using Xunit;

namespace Bookshelf.Domain.Tests.User
{
    public class UserTest
    {
        public UserTest()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact]
        public void CreateUser_Returns_throws_InvalidPasswordException()
        {
            Assert.Throws<InvalidPasswordException>
            (() => new Domain.User.User(
                "Uname2137",
                "mail",
                "haslo"));
        }
        
        [Fact]
        public void EditUser_Returns_Invalid_Response()
        {
            var user = new Domain.User.User("NowyUname", "mail@mail.mail", "KoxHaslo");

            Assert.NotEqual("StaryUname", user.Username);
            Assert.Equal("mail@mail.mail", user.Email);
            Assert.Equal("KoxHaslo", user.Password);
        }
        
        [Fact]
        public void EditUser_Returns_Correct_Response()
        {
            var user = new Domain.User.User("NowyUname", "mail@mail.mail", "KoxHaslo");

            Assert.Equal("NowyUname", user.Username);
            Assert.Equal("mail@mail.mail", user.Email);
            Assert.Equal("KoxHaslo", user.Password);
        }

    }
}