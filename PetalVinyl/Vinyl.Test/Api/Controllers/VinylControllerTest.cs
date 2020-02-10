using AutoFixture;
using Common.Infrastructure.Models.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Vinyl.Api.Constants;
using Vinyl.Api.Controllers;
using Vinyl.Domain.Interfaces;

namespace Vinyl.Test.Api.Controllers
{
    [TestClass, ExcludeFromCodeCoverage]
    public class VinylControllerTest
    {
        private Fixture fixture;
        private IVinylService vinylServiceMock;
        private VinylController vinylController;

        [TestInitialize]
        public void Test_Initialize()
        {
            fixture = new Fixture();
            vinylServiceMock = Substitute.For<IVinylService>();
            vinylController = new VinylController(vinylServiceMock);
        }

        [TestMethod]
        public void GetRandomVinyls_NumberOfVinylsBelow1_MessageShouldBeVinylBetweenOneAndFive()
        {
            //Arrange
            var expectedMessages = new List<string> {Messages.VINYL_NUMBER_BETWEEN_ONE_AND_FIVE };
            //Act
            var controllerResult = vinylController.GetRandomVinyls(0).Result as BadRequestObjectResult;
            //Assert
            CollectionAssert.AreEquivalent(expectedMessages, controllerResult.Value as List<string>);
        }

        [TestMethod]
        public void GetRandomVinyls_NumberOfVinylsAbove5_MessageShouldBeVinylBetweenOneAndFive()
        {
            //Arrange
            var expectedMessages = new List<string> { Messages.VINYL_NUMBER_BETWEEN_ONE_AND_FIVE };
            //Act
            var controllerResult = vinylController.GetRandomVinyls(6).Result as BadRequestObjectResult;
            //Assert
            CollectionAssert.AreEquivalent(expectedMessages, controllerResult.Value as List<string>);
        }

        [TestMethod]
        public void GetRandomVinyls_ServiceReturnsSucces_ShouldReturnVinyls()
        {
            //Arrange
            var numberOfVinyls = 4;
            var expectedResult = new SuccesResponse<List<Vinyl.Domain.Models.Vinyl>>(
                fixture.Create<List<Vinyl.Domain.Models.Vinyl>>()); 
                         
            vinylServiceMock.GetRandomVinyls(numberOfVinyls).Returns(expectedResult);
            //Act
            var controllerResult = vinylController.GetRandomVinyls(numberOfVinyls).Result as OkObjectResult;
            //Assert
            CollectionAssert.AreEquivalent(expectedResult.Response, 
                controllerResult.Value as List<Vinyl.Domain.Models.Vinyl>);
        }

        [TestMethod]
        public void GetRandomVinyls_ServiceReturnsNotSucces_ShouldReturnErrors()
        {
            //Arrange
            var numberOfVinyls = 4;
            var expectedResult = new ErrorResponse<List<Vinyl.Domain.Models.Vinyl>>(
                fixture.Create<List<string>>());

            vinylServiceMock.GetRandomVinyls(numberOfVinyls).Returns(expectedResult);
            //Act
            var controllerResult = vinylController.GetRandomVinyls(numberOfVinyls).Result as OkObjectResult;
            //Assert
            CollectionAssert.AreEquivalent(expectedResult.ErrorMessages,
                controllerResult.Value as List<string>);
        }
    }
}
