using Common.Infrastructure.Models.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Common.Test.Models.Common
{
    [TestClass, ExcludeFromCodeCoverage]
    public class SuccesResponseTest
    {
        [TestMethod]
        public void Constructor_Always_ErrorMessagesShouldBeEmpty()
        {
            //Arrange
            //Act
            var testResult = new SuccesResponse<object>(new object());
            //Assert
            Assert.AreEqual(0, testResult.ErrorMessages.Count);
        }

        [TestMethod]
        public void Constructor_Always_IsSuccesShouldBeTrue()
        {
            //Arrange
            //Act
            var testResult = new SuccesResponse<object>(new object());
            //Assert
            Assert.IsTrue(testResult.IsSucces);
        }

        [TestMethod]
        public void Constructor_Always_ResponseShouldBeAssignedWithParameter()
        {
            //Arrange
            var expectedResponse = new object();
            //Act
            var testResult = new SuccesResponse<object>(expectedResponse);
            //Assert
            Assert.AreEqual(expectedResponse, testResult.Response);
        }
    }
}
