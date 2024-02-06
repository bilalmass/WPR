// using System;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;
// using Xunit;
// using Controller; // Add the namespace containing OnderzoekController
// using Models; // Add the namespace containing Onderzoek

// namespace Tests
// {
//     public class OnderzoekControllerTests
//     {
//         private readonly DbContextOptions<MyDbContext> _options; // Replace MyDbContext with the actual name of your DbContext class

//         public OnderzoekControllerTests()
//         {
//             // Arrange: Configure the in-memory database
//             _options = new DbContextOptionsBuilder<MyDbContext>() // Replace MyDbContext
//                 .UseInMemoryDatabase(databaseName: "TestDatabase")
//                 .Options;

//             // Arrange: Create a new instance of the DbContext with the in-memory database
//             using (var dbContext = new MyDbContext(_options)) // Replace MyDbContext
//             {
//                 // Arrange: Add some data to the in-memory database
//                 dbContext.Onderzoeken.AddRange(
//                     new Onderzoek { OnderzoekId = 1, Titel = "Onderzoek 1" },
//                     new Onderzoek { OnderzoekId = 2, Titel = "Onderzoek 2" }
//                 );

//                 dbContext.SaveChanges();
//             }
//         }

//         [Fact]
//         public async Task GetOnderzoek_ReturnsAllOnderzoeken()
//         {
//             // Arrange: Create a new instance of the OnderzoekController with the in-memory database
//             using (var dbContext = new MyDbContext(_options)) // Replace MyDbContext
//             {
//                 var controller = new OnderzoekController(dbContext);

//                 // Act: Call the GetOnderzoek method
//                 var result = await controller.GetOnderzoek();

//                 // Assert: Check if the result is not null and it contains the expected onderzoeken
//                 Assert.NotNull(result);
//                 Assert.Equal(2, result.Value.Count());
//             }
//         }
//     }
// }
