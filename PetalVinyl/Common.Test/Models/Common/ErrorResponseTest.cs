using AutoFixture;
using Common.Infrastructure.Models.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Common.Test.Models.Common
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ErrorResponseTest
    {
        private Fixture fixture;

        [TestInitialize]
        public void Test_Initialize()
        {
            fixture = new Fixture();
        }
        
        [TestMethod]
        public void Constructor_Always_ShouldAddErrorMessagesToList()
        {
            //Arrange
            var expectedMessages = fixture.Create<List<string>>();
            //Act
            var testResult = new ErrorResponse<object>(expectedMessages);
            //Assert
            CollectionAssert.AreEquivalent(expectedMessages, testResult.ErrorMessages);
        }

        [TestMethod]
        public void Constructor_Always_IsSuccesShouldBeFalse()
        {
            //Arrange
            //Act
            var testResult = new ErrorResponse<object>(fixture.Create<List<string>>());
            //Assert
            Assert.IsFalse(testResult.IsSucces);
        }

        [TestMethod]
        public void Constructor_Always_ResponseShouldBeNull()
        {
            //Arrange
            //Act
            var testResult = new ErrorResponse<object>(fixture.Create<List<string>>());
            //Assert
            Assert.IsNull(testResult.Response);
        }
    }
}
