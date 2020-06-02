using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Models.Sale
{
    public class Sale
    {
        //This is actually the ObjectId
        public ObjectId Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ProductId { get; set; }
        public SaleStatus Status { get; set; }
        public SaleInventory Inventory { get; set; }
        public SalePlataform Plataform { get; set; }
        public Sale()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }

    public class SaleInventory
    {
        public decimal TotalValue { get; set; }
        public int QuantitySold { get; set; }
    }

    //TODO
    public enum SalePlataform
    {
        B2W,
        Americanas,
        MercadoLivre,
        LeroyMerlin,
        Invalid
    }

    public enum SaleStatus
    {
        Pending,
        Approved,
        Processing,
        Shipped,
        Opened,
        Closed,
        Invalid
    }
}
