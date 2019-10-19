using HLess.Logic.Facades;
using HLess.Logic.Facades.Interfaces;
using HLess.Logic.Services.Interfaces;
using HLess.Models.Entities;
using HLess.Models.Requests;
using Moq;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace HLess.UnitTests.Logic.Facades
{
    public class AccountFacadeTests
    {
        private readonly IAccountFacade sut;
        private readonly Mock<IAccountService> accountService;

        public AccountFacadeTests()
        {
            this.accountService = new Mock<IAccountService>();
            this.sut = new AccountFacade(this.accountService.Object);
        }

        [SetUp]
        public void SetUp()
        {
            this.accountService.Reset();
        }

        [Test]
        public async Task Register_Should_Create_User_And_Linked_Account()
        {
            var model = new CreateAccountDto
            {
                AccountName = "test-account",
                Password = "password",
                Email = "test@email.com"
            };

            ApplicationUser registerCallUser = null;

            this.accountService.Setup(x => x.Register(It.IsAny<ApplicationUser>(), "password"))
                .Callback((ApplicationUser user, string password) => { registerCallUser = user; });

            this.accountService.Setup(x => x.UpdateUser(It.IsAny<ApplicationUser>()));

            await this.sut.Register(model);

            Assert.AreEqual(model.Email, registerCallUser.Email);
            Assert.AreEqual(model.Email, registerCallUser.UserName);
            Assert.AreEqual(model.AccountName, registerCallUser.AccountUsers.First().Account.Name);
            Assert.AreEqual(registerCallUser, registerCallUser.AccountUsers.First().Account.CreatedByUser);
            Assert.AreEqual(model.AccountName, registerCallUser.AccountUsers.First().Account.Sites.First().Name);
            Assert.IsTrue(registerCallUser.AccountUsers.First().Account.Sites.First().IsDefault);

            this.accountService.Verify(x => x.UpdateUser(registerCallUser));
        }
    }
}
