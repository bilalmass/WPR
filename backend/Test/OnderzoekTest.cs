using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Controller;
using Models;

namespace Tests
{
    public class OnderzoekControllerTests
    {
        private readonly DbContextOptions<DbContext> _options;

        public OnderzoekControllerTests()
        {
            // Arrange: Configureer de in-memory database
            _options = new DbContextOptionsBuilder<DbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Arrange: Maak een nieuwe instantie van de DbContext met de in-memory database
            var dbContext = new DbContext(_options);

            // Arrange: Voeg wat gegevens toe aan de in-memory database
            dbContext.Onderzoeken.AddRange(
                new Onderzoek { OnderzoekId = 1, Titel = "Onderzoek 1" },
                new Onderzoek { OnderzoekId = 2, Titel = "Onderzoek 2" }
            );

            dbContext.SaveChanges();
        }

        [Fact]
        public async Task GetOnderzoek_ReturnsAllOnderzoeken()
        {
            // Arrange: Maak een nieuwe instantie van de OnderzoekController met de in-memory database
            var controller = new OnderzoekController(new DbContext(_options));

            // Act: Roep de GetOnderzoek methode aan
            var result = await controller.GetOnderzoek();

            // Assert: Controleer of het resultaat niet null is en dat het de verwachte onderzoeken bevat
            Assert.NotNull(result);
            Assert.Equal(2, result.Value.Count());
        }
    }
}