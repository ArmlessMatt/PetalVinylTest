using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Vinyl.Test.Domain.Models
{
    [TestClass, ExcludeFromCodeCoverage]
    public class VinylTest
    {
        [TestMethod]
        public void Constructeur_Always_TitleNullAndArtistsEmpty()
        {
            //Arrange
            //Act
            var vinyl = new Vinyl.Domain.Models.Vinyl();
            //Assert
            Assert.IsNull(vinyl.Title);
            Assert.IsNotNull(vinyl.Artists);
            Assert.AreEqual(0, vinyl.Artists.Count);
        }
    }
}
