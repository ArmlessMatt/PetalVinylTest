using AutoFixture;
using Common.Infrastructure.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Common.Test.Models.HttpClient
{
    [TestClass, ExcludeFromCodeCoverage]
    public class QueryParameterTest
    {
        private Fixture fixture;

        [TestInitialize]
        public void Test_Initialize()
        {
            fixture = new Fixture();
        }

        [TestMethod]
        public void ToString_Always_ShouldReturnParamNamePlusEqualPlusValue()
        {
            //Arrange
            var queryParam = new QueryParameter
            {
                Name = fixture.Create<string>(),
                Value = fixture.Create<string>()
            };
            //Act
            var testResult = queryParam.ToString();
            //Assert
            Assert.AreEqual(queryParam.Name + "=" + queryParam.Value, testResult);
        }
    }
}
