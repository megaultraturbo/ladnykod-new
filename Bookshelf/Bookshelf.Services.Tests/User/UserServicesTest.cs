using System;
using System.Threading.Tasks;
using Bookshelf.Domain.DomainExceptions;
using Bookshelf.IData.User;
using Bookshelf.IServices.Requests;
using Bookshelf.IServices.User;
using Bookshelf.Services.User;
using Moq;
using Xunit;

namespace Bookshelf.Services.Tests.User
{
    public class UserServiceTest
    {
        private readonly IUserService _userService;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        
        public UserServiceTest()
        {
            //Arrange
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }
        
        [Fact]
        public void CreateUser_Returns_throws_InvalidPasswordException()
        {
            var user = new CreateUser
            {
                UserName = "Username",
                Email = "em",
                Password = "2ft"
            };

            Assert.ThrowsAsync<InvalidPasswordException>(() => _userService.CreateUser(user));
        }
        
        [Fact]
        public async Task CreateUser_Returns_Correct_Response()
        {
            var user = new CreateUser
            {
                UserName = "Name",
                Email = "email@email.email",
                Password = "LongPword"
            };
            
            int expectedResult = 1;
            _userRepositoryMock.Setup(x => x.AddUser
                (new Domain.User.User
                (user.UserName, 
                    user.Email, 
                    user.Password)))
                .Returns(Task.FromResult(expectedResult));
            
            //Act
            var result = await _userService.CreateUser(user);

            //Assert
            Assert.IsType<Domain.User.User>(result);
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.UserId);
        }

    }
}
