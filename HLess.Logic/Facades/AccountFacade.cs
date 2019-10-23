using HLess.Logic.Facades.Interfaces;
using HLess.Logic.Services.Interfaces;
using HLess.Models.Entities;
using HLess.Models.Requests;
using HLess.Models.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HLess.Logic.Facades
{
    public class AccountFacade : IAccountFacade
    {
        private readonly IAccountService accountService;

        public AccountFacade(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public async Task<CreateAccountSuccessDto> Register(CreateAccountDto model)
        {
            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            await this.accountService.Register(user, model.Password);

            user.AccountUsers = new List<AccountUser>(){
                new AccountUser {
                    Account = new Account
                    {
                      Name = model.AccountName,
                      CreatedByUser = user,
                      CreatedDate = DateTime.Now,
                      Sites = new List<Site>()
                      {
                          new Site
                          {
                              Name = model.AccountName,
                              IsDefault = true,
                              CreatedByUser = user,
                              CreatedDate = DateTime.Now
                          }
                      }
                    }
                }
            };

            await this.accountService.UpdateUser(user);

            return new CreateAccountSuccessDto();
        }
    }
}
