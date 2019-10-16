using HLess.Logic.Services;
using HLess.Logic.Services.Interfaces;
using HLess.Logic.Wrappers.Interfaces;
using HLess.Models.Entities;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace HLess.UnitTests.Logic.Services
{
    public class AccountServiceTests
    {
        private readonly IAccountService sut;
        private readonly Mock<IUserManagerWrapper> userManagerWrapper;

        public AccountServiceTests()
        {
            this.userManagerWrapper = new Mock<IUserManagerWrapper>();
            this.sut = new AccountService(userManagerWrapper.Object);
        }

        [SetUp]
        public void SetUp()
        {
            this.userManagerWrapper.Reset();
        }

        [Test]
        public async Task Register_Should_Call_Wrapper()
        {
            var user = new ApplicationUser();
            this.userManagerWrapper.Setup(x => x.Register(user, It.IsAny<string>()));

            await sut.Register(user, "password");

            this.userManagerWrapper.Verify(x => x.Register(user, "password"));
        }

        [Test]
        public async Task UpdateUser_Should_Call_Wrapper()
        {
            var user = new ApplicationUser();
            this.userManagerWrapper.Setup(x => x.UpdateAsync(user));

            await sut.UpdateUser(user);

            this.userManagerWrapper.Verify(x => x.UpdateAsync(user));
        }
    }
}
