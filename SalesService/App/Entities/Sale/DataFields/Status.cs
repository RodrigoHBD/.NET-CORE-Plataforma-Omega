using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesService.App.Models;

namespace SalesService.App.Entities.SaleDataFields
{
    public class StatusEntity
    {
        public static void Valdiate(SaleStatus status)
        {
            try
            {

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string ToString(SaleStatus status)
        {
            return Statuses.Find(_status => _status.Enum == status).Name;
        }

        public static SaleStatus Parse(string name)
        {
            var status = Statuses.Find(_status => _status.Name == name);

            if(status == null)
            {
                throw new Exception($"Status {name} nao existe.");
            }
            return status.Enum;
        }

        private static List<Status> Statuses { get; } = new List<Status>()
        {
            new Status()
            {
                Name = "approved",
                Enum = SaleStatus.Approved
            },
            new Status()
            {
                Name = "pending",
                Enum = SaleStatus.Pending
            }
        };

        private class Status
        {
            public string Name { get; set; }
            public SaleStatus Enum { get; set; }
        }
    }
}
