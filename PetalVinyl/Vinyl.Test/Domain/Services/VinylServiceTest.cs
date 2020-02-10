using AutoFixture;
using Common.Infrastructure.Models.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Vinyl.Domain.Interfaces;
using Vinyl.Domain.Services;

namespace Vinyl.Test.Domain.Services
{
    [TestClass, ExcludeFromCodeCoverage]
    public class VinylServiceTest
    {
        private Fixture fixture;
        private IVinylDataService vinylDataServiceMock;
        private VinylService vinylService;

        [TestInitialize]
        public void Test_Initialize()
        {
            fixture = new Fixture();
            vinylDataServiceMock = Substitute.For<IVinylDataService>();
            vinylService = new VinylService(vinylDataServiceMock);
        }

        [TestMethod]
        public void GetRandomVinyls_TotalVinylsFail_ShouldReturnErrorsFromDataServiceAndNoVinyls()
        {
            //Arrange
            var totalVinylsResult = fixture.Create<ErrorResponse<int>>();
            vinylDataServiceMock.GetTotalVinyls().Returns(totalVinylsResult);
            //Act
            var serviceResult = vinylService.GetRandomVinyls(4);
            //Assert
            Assert.IsNull(serviceResult.Response);
            Assert.IsFalse(serviceResult.IsSucces);
            CollectionAssert.AreEquivalent(totalVinylsResult.ErrorMessages, serviceResult.ErrorMessages);
        }

        [TestMethod]
        public void GetRandomVinyls_VinylsGetFail_ShouldReturnErrorsFromDataServiceAndNoVinyls()
        {
            //Arrange
            var totalVinylsResult = new SuccesResponse<int>(10);
            var getVinylsResult = fixture.Create<ErrorResponse<List<Vinyl.Domain.Models.Vinyl>>>();
            vinylDataServiceMock.GetTotalVinyls().Returns(totalVinylsResult);
            vinylDataServiceMock.GetVinylsByIndex(Arg.Any<List<int>>()).Returns(getVinylsResult);
            //Act
            var serviceResult = vinylService.GetRandomVinyls(4);
            //Assert
            Assert.IsNull(serviceResult.Response);
            Assert.IsFalse(serviceResult.IsSucces);
            CollectionAssert.AreEquivalent(getVinylsResult.ErrorMessages, serviceResult.ErrorMessages);
        }

        [TestMethod]
        public void GetRandomVinyls_VinylsGetSucces_ShouldReturnVinylsWithNoErrors()
        {
            //Arrange
            var vinyls = fixture.Create<List<Vinyl.Domain.Models.Vinyl>>();
            var totalVinylsResult = new SuccesResponse<int>(10);
            var getVinylsResult = new SuccesResponse<List<Vinyl.Domain.Models.Vinyl>>(vinyls);
            vinylDataServiceMock.GetTotalVinyls().Returns(totalVinylsResult);
            vinylDataServiceMock.GetVinylsByIndex(Arg.Any<List<int>>()).Returns(getVinylsResult);
            //Act
            var serviceResult = vinylService.GetRandomVinyls(4);
            //Assert
            Assert.AreEqual(vinyls, serviceResult.Response);
            Assert.IsTrue(serviceResult.IsSucces);
            Assert.AreEqual(0, serviceResult.ErrorMessages.Count);
        }
    }
}
