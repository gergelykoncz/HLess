using HLess.Models.Requests;
using HLess.Models.Responses;
using System.Threading.Tasks;

namespace HLess.Logic.Facades.Interfaces
{
    public interface IAccountFacade
    {
        Task<CreateAccountSuccessDto> Register(CreateAccountDto model);
    }
}
