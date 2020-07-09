using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.MercadoLivreModels.Output
{
    public class Account
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Owner { get; set; } = "";
        public bool IsSynced { get; set; }
        public string LastSyncedAt { get; set; } = "";
        public string AddedAt { get; set; } = "";
    }
}
