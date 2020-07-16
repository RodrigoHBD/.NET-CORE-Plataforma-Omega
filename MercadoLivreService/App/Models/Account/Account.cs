﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Models
{
    public class Account
    {
        public ObjectId Id { get; set; }
        public long MercadoLivreId { get; set; } 
        public string Owner { get; set; } = "";
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Description { get; set; } = "";
        public AccountTokens Tokens { get; set; } = new AccountTokens();
        public AccountStates States { get; set; } = new AccountStates();
        public AccountDates Dates { get; set; } = new AccountDates();
    }

    public class AccountTokens
    {
        public string AccessToken { get; set; } = "";
        public string RefreshToken { get; set; } = "";
    }

    public class AccountStates
    {
        public bool IsSynced { get; set; } = false;
    }

    public class AccountDates
    {
        public DateTime AddedAt { get; set; }
        public DateTime LastSyncedAt { get; set; }
        public DateTime TokensLastRefreshedAt { get; set; }
    }

}
