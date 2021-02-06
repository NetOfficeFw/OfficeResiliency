using System;
using System.IO;
using NUnit.Framework;

namespace NetOffice.Tools
{
    [TestFixture]
    public class OfficeResiliencyTests
    {
        [Test]
        public void Parse_NetFrameworkAddin_ReturnsDisabledItem()
        {
            // Arrange
            var filepath = Path.Combine(TestContext.CurrentContext.TestDirectory, "data", "NetFrameworkAddinResiliency.bin");
            var data = File.ReadAllBytes(filepath);

            // Act
            var actualResult = OfficeResiliency.Parse(data);

            // Assert
            Assert.IsNotNull(actualResult);
        }
    }
}
