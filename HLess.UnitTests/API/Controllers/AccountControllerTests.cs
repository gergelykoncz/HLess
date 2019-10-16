using HLess.API.Controllers;
using HLess.Logic.Facades.Interfaces;
using HLess.Models.Requests;
using HLess.Models.Responses;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace HLess.UnitTests.API.Controllers
{
    public class AccountControllerTests
    {
        private readonly AccountController sut;
        private readonly Mock<IAccountFacade> accountFacade;

        public AccountControllerTests()
        {
            this.accountFacade = new Mock<IAccountFacade>();
            this.sut = new AccountController(accountFacade.Object);
        }

        [SetUp]
        public void SetUp()
        {
            this.accountFacade.Reset();
        }

        [Test]
        public async Task Register_Should_Call_Facade()
        {
            var model = new CreateAccountDto();
            var facadeResult = new CreateAccountSuccessDto();

            this.accountFacade.Setup(x => x.Register(model)).Returns(Task.FromResult(facadeResult));

            var callResult = await this.sut.Register(model);

            this.accountFacade.Verify(x => x.Register(model));
        }
    }
}
