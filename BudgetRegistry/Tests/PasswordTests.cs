using BudgetRegistry.Model;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetRegistry.Tests
{
    [TestFixture]
    public class PasswordTests
    {
        [Test]
        public void EncryptPassword_EncryptedPasswordShouldBeDifferent()
        {
            //Arrange
            var password = "test";
            //Act
            var encryptedPassword = Password.EncryptPassword(password);
            //Asstert
            password.Should().NotBe(encryptedPassword);            
        }

        [Test]
        public void CheckPassword_PasswordAndEncryptedPasswordShouldBeSame()
        {
            //Arrange
            var password = "test";
            var encryptedPassword = Password.EncryptPassword(password);
            //Act
            bool result = Password.CheckPassword(password, encryptedPassword);
            //Assert
            result.Should().BeTrue();

        }
    }
}
