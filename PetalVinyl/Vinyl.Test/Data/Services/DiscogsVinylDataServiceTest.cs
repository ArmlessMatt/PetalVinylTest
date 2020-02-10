using AutoFixture;
using Common.Infrastructure.Interfaces;
using Common.Infrastructure.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using Vinyl.Data.Constants;
using Vinyl.Data.Models.Discogs;
using Vinyl.Data.Services;

namespace Vinyl.Test.Data.Services
{
    [TestClass, ExcludeFromCodeCoverage]
    public class DiscogsVinylDataServiceTest
    {
        private Fixture fixture;
        private IHttpClient httpClientMock;
        private DiscogsVinylDataService vinylDataService;

        [TestInitialize]
        public void Test_Initialize()
        {
            fixture = new Fixture();
            httpClientMock = Substitute.For<IHttpClient>();
            vinylDataService = new DiscogsVinylDataService(httpClientMock);
        }

        [TestMethod]
        public void GetTotalVinyls_HttpReturnsOk_ShouldReturnSuccesWithTotalAmountOfVinyls()
        {
            //Arrange
            var expectedQueryParam = new QueryParameter
            {
                Name = DiscogsConstants.PER_PAGE_QUERY_PARAM_NAME,
                Value = "1"
            };
            var mockHttpResponse = new HttpResponse<DiscogsResponse>
            {
                Status = HttpStatusCode.OK,
                Content = fixture.Create<DiscogsResponse>()
            };
            httpClientMock.Get<DiscogsResponse>(DiscogsConstants.URL,
                DiscogsConstants.PATH_TO_COLLECTION,
                Arg.Is<List<QueryParameter>>(arg => arg.Any(param => param.Name ==
                expectedQueryParam.Name && param.Value == expectedQueryParam.Value))).Returns(mockHttpResponse);
            //Act
            var totalVinyls = vinylDataService.GetTotalVinyls();
            //Assert
            Assert.IsTrue(totalVinyls.IsSucces);
            Assert.AreEqual(mockHttpResponse.Content.PaginationInfo.NumberOfElements, totalVinyls.Response);
            Assert.AreEqual(0, totalVinyls.ErrorMessages.Count);
        }

        [TestMethod]
        public void GetTotalVinyls_HttpReturnsNotOk_ShouldReturnFailWithMessage()
        {
            //Arrange
            var expectedQueryParam = new QueryParameter
            {
                Name = DiscogsConstants.PER_PAGE_QUERY_PARAM_NAME,
                Value = "1"
            };
            var mockHttpResponse = new HttpResponse<DiscogsResponse>
            {
                Status = HttpStatusCode.InternalServerError
            };
            httpClientMock.Get<DiscogsResponse>(DiscogsConstants.URL,
                DiscogsConstants.PATH_TO_COLLECTION,
                Arg.Is<List<QueryParameter>>(arg => arg.Any(param => param.Name ==
                expectedQueryParam.Name && param.Value == expectedQueryParam.Value))).Returns(mockHttpResponse);
            //Act
            var totalVinyls = vinylDataService.GetTotalVinyls();
            //Assert
            Assert.IsFalse(totalVinyls.IsSucces);
            Assert.AreEqual(1, totalVinyls.ErrorMessages.Count);
            Assert.AreEqual(DiscogsConstants.ERROR_MESSAGE_DISCOGS_CALL_FAILED, totalVinyls.ErrorMessages[0]);
        }

        //Test for method GetVinylsListFromDiscogsResponse should go here
    }
}
