// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Moq;
// using System.Threading.Tasks;
// using Xunit;
// using Controller;
// using Models;

// namespace Tests
// {
//     public class UnitTest1
//     {
//         private readonly Mock<RoleManager<Rol>> _mockRoleManager;
//         private readonly Mock<UserManager<Bedrijf>> _mockUserManager;
//         private readonly Mock<SignInManager<Bedrijf>> _mockSignInManager;
//         private readonly DbContextOptions<DbContext> _options;

//         public UnitTest1()
//         {
//             _mockRoleManager = new Mock<RoleManager<Rol>>(Mock.Of<IRoleStore<Rol>>(), null, null, null, null);
//             _mockUserManager = new Mock<UserManager<Bedrijf>>(Mock.Of<IUserStore<Bedrijf>>(), null, null, null, null, null, null);
//             _mockSignInManager = new Mock<SignInManager<Bedrijf>>(_mockUserManager.Object, null, null, null, null, null, null);

//             _options = new DbContextOptionsBuilder<DbContext>()
//                 .UseInMemoryDatabase(databaseName: "TestDatabase")
//                 .Options;
//         }

//         [Fact]
//         public async Task TestCreateAccount()
//         {
//             // Arrange
//             var dbContext = new DbContext(_options);
//             var controller = new RegistreerBedrijfController( _mockSignInManager.Object, _mockUserManager.Object, _mockRoleManager.Object);

//             var request = new RegistreerBedrijfController.CreateBedrijfRequestData
//             {
//                 GebruikersNaam = "testusername",
//                 Email = "test@email.com",
//                 Wachtwoord = "testpassword",
//                 Naam = "Test Company",
//                 Informatie = "Information about the company",
//                 Locatie = "Location of the company",
//                 Link = "https://www.example.com"
//             };

//             // Act
//             var result = await controller.CreateAccount(request);

//             // Assert
//             var createdAtResult = Assert.IsType<CreatedAtActionResult>(result);
//             var returnedValue = Assert.IsAssignableFrom<Bedrijf>(createdAtResult.Value);
//             Assert.Equal(request.GebruikersNaam, returnedValue.UserName);
//             Assert.Equal(request.Email, returnedValue.Email);
//             Assert.Equal(request.Naam, returnedValue.Naam);
//             Assert.Equal(request.Informatie, returnedValue.Informatie);
//             Assert.Equal(request.Locatie, returnedValue.Locatie);
//             Assert.Equal(request.Link, returnedValue.Link);
//         }
//     }
// }