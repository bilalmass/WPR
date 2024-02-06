using Xunit;
using Moq;
using Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Controller.Tests
{
    public class RegistreerBeheerderControllerTests
    {
        [Fact]
        public async Task RegistreerBeheerderRolTest()
        {
            
            var mockUserManager = new Mock<UserManager<Gebruiker>>(Mock.Of<IUserStore<Gebruiker>>(), null, null, null, null, null, null, null, null);
            var mockSignInManager = new Mock<SignInManager<Gebruiker>>(mockUserManager.Object, null, null, null, null, null, null);
            var mockRoleManager = new Mock<RoleManager<Rol>>(null, null, null, null);
            var logger = Mock.Of<ILogger<RegistreerBeheerderController>>();

            var controller = new RegistreerBeheerderController(mockSignInManager.Object, mockUserManager.Object, mockRoleManager.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext { User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, "test") })) }
                }
            };

            var requestData = new CreateBeheerderRequestData
            {
                GebruikersNaam = "testuser",
                Email = "test@example.com",
                Wachtwoord = "password123",
                Naam = "Test User"
            };
            
            var result = await controller.CreateAccount(requestData);

            Assert.NotNull(result);
            Assert.IsType<CreatedAtActionResult>(result);
            var createdResult = result as CreatedAtActionResult;
            Assert.Equal("Beheerder", createdResult.Value.Discriminator);

            mockUserManager.Verify(manager => manager.AddToRoleAsync(It.IsAny<Gebruiker>(), It.Is<string>(r => r == "Beheerder")), Times.Once());
        }
    }
}
