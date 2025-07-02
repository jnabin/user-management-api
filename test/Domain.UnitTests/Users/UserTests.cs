using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users;
using FluentAssertions;

namespace Domain.UnitTests.Users
{
    public class UserTests
    {
        [Fact]
        public void Create_SHould_SetPropertyValues()
        {
            //Arrange

            //Act
            var user = User.Create(UserData.Email, UserData.FirstName, UserData.LastName);

            //Assert
            user.FirstName.Should().Be(UserData.FirstName);
            user.LastName.Should().Be(UserData.LastName);
            user.Email.Should().Be(UserData.Email);
        }
    }
}
