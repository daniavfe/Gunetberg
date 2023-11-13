using FluentValidation;
using Gunetberg.Application;
using Gunetberg.Domain.User;
using Gunetberg.Port.Output;
using Gunetberg.Port.Output.Repository;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Gunetberg.Test
{
    public class UserServiceTest
    {


        [Fact]
        public async void Create_User_Throws_Validation_Exception_When_Email_Is_empty()
        {
            var logger = new Mock<ILogger<UserService>>();
            var userRepository = new Mock<IUserRepository>();
            var hashClient = new Mock<IHashClient>();

            var userService = new UserService(logger.Object, userRepository.Object, hashClient.Object);

            var exception = await Assert.ThrowsAsync<ValidationException>(()=> userService.CreateUser(new CreateUserRequest
            {
                Email = string.Empty,
                Alias = "alias",
                Password = "pass",
                PasswordCheck = "pass"
            }));        
        }

        [Fact]
        public async void Testing()
        {
            Assert.Equal(1, 1);
        }


    }
}
