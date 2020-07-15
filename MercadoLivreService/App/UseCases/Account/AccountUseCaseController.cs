﻿using MercadoLivreService.App.Entities;
using MercadoLivreService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class AccountUseCaseController
    {
        public static async Task AddNewAccountAsync(IAddAccountRequest request)
        {
            try
            {
                var accountTokens = await ExchangeCodeForTokens.Execute(request.AuthCode);
                var account = CreateAccount.Execute(request, accountTokens);
                await AccountEntity.ValidateNew(account);
                await RegisterAccount.Execute(account);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<IAccountList> SearchAccountsAsync(ISearchAccountsReq request)
        {
            try
            {
                await AccountSearchEntity.ValidateSearch(request);
                return await SearchAccounts.Execute(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<AccountTokens> RefreshAndUpdateTokens(string id)
        {
            try
            {
                var account = await GetAccountById.Execute(id);
                var newTokens = await RefreshAccountTokens.Execute(account.Tokens.RefreshToken);
                await UpdateAccountTokens.Execute(id, newTokens);
                return newTokens;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<Account> GetAccountByIdAsync(string id)
        {
            try
            {
                return await GetAccountById.Execute(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
