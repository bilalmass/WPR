// using Xunit;
// using Moq;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Mvc;
// using Controller;
// using Models;
// using System.Threading.Tasks;

// public class BedrijfTest
// {
//     private readonly Mock<RoleManager<Rol>> _mockRoleManager;
//     private readonly Mock<UserManager<Gebruiker>> _mockUserManager;
//     private readonly Mock<SignInManager<Gebruiker>> _mockSignInManager;
//     private readonly DbContextOptions<DbContext> _options;
//     private readonly DbContext _dbContext;
//     private readonly RegistreerBedrijfController _controller;

//     public BedrijfTest()
//     {
//         _mockRoleManager = new Mock<RoleManager<Rol>>(Mock.Of<IRoleStore<Rol>>(), null, null, null, null);
//         _mockUserManager = new Mock<UserManager<Gebruiker>>(new Mock<IUserStore<Gebruiker>>().Object, null, null, null, null, null, null);
//         _mockSignInManager = new Mock<SignInManager<Gebruiker>>(_mockUserManager.Object, null, null, null, null, null, null);

//         _options = new DbContextOptionsBuilder<DbContext>()
//             .UseInMemoryDatabase(databaseName: "TestDatabase")
//             .Options;

//         _dbContext = new DbContext(_options);

//         _controller = new RegistreerBedrijfController(_mockSignInManager.Object, _mockUserManager.Object, _mockRoleManager.Object);
//     }

//     [Fact]
//     public async Task TestCreateAccount()
//     {
//         // Arrange
//         var request = new RegistreerBedrijfController.CreateBedrijfRequestData
//         {
//             GebruikersNaam = "testusername",
//             Email = "test@email.com",
//             Wachtwoord = "testpassword",
//             Naam = "Test Company",
//             Informatie = "Information about the company",
//             Locatie = "Location of the company",
//             Link = "https://www.example.com"
//         };

//         // Act
//         var result = await _controller.CreateAccount(request);

//         // Assert
//         var createdAtResult = Assert.IsType<CreatedAtActionResult>(result);
//         var returnedValue = Assert.IsAssignableFrom<Bedrijf>(createdAtResult.Value); // Check against Bedrijf
//         Assert.Equal(request.GebruikersNaam, returnedValue.UserName);
//         Assert.Equal(request.Email, returnedValue.Email);
//         Assert.Equal(request.Naam, returnedValue.Naam);
//         Assert.Equal(request.Informatie, returnedValue.Informatie);
//         Assert.Equal(request.Locatie, returnedValue.Locatie);
//         Assert.Equal(request.Link, returnedValue.Link);
//     }
// }
