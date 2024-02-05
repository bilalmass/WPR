using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Xunit;
using Controller;

namespace Tests
{
    public class OnderzoekControllerTests
    {
        [Fact]
        public async Task CreateOnderzoek_ReturnsCreatedAtAction()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase") // Use only the in-memory provider
                .Options;

            using (var dbContext = new DbContext(options))
            {
                var controller = new OnderzoekController(dbContext);
                var requestData = new CreateOnderzoekRequestData
                {
                    Titel = "Test Onderzoek",
                    Beschrijving = "Dit is een test onderzoek",
                    Start = DateTime.Now,
                    Categorie = "TestCategory",
                    Beloning = "TestBeloning"
                };

                // Act
                var result = await controller.CreateOnderzoek(requestData);

                // Assert
                Assert.IsType<CreatedAtActionResult>(result);
                var createdAtActionResult = (CreatedAtActionResult)result;
                Assert.IsType<Onderzoek>(createdAtActionResult.Value);

                var createdOnderzoek = (Onderzoek)createdAtActionResult.Value;

                // Check if the data is correctly stored in the in-memory database
                Assert.Equal(requestData.Titel, createdOnderzoek.Titel);
                Assert.Equal(requestData.Beschrijving, createdOnderzoek.Beschrijving);
                Assert.Equal(requestData.Start, createdOnderzoek.Start);
                Assert.Equal(requestData.Categorie, createdOnderzoek.Categorie);
                Assert.Equal(requestData.Beloning, createdOnderzoek.Beloning);

                // Check if the data is correctly saved in the in-memory database
                var savedOnderzoek = dbContext.Onderzoeken.FirstOrDefault();
                Assert.NotNull(savedOnderzoek);
                Assert.Equal(requestData.Titel, savedOnderzoek.Titel);
                Assert.Equal(requestData.Beschrijving, savedOnderzoek.Beschrijving);
                Assert.Equal(requestData.Start, savedOnderzoek.Start);
                Assert.Equal(requestData.Categorie, savedOnderzoek.Categorie);
                Assert.Equal(requestData.Beloning, savedOnderzoek.Beloning);
            }
        }
    }
}
