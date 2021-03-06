﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Models
{
    public class Sale
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string PlatformSaleId { get; set; }
        public DateTime CreatedAt { get; set; }
        public SaleStatus Status { get; set; }
        public SaleInventory Inventory { get; set; }
        public string Plataform { get; set; }
        public Sale()
        {
            Status = SaleStatus.Pending;
            Inventory = new SaleInventory();
            Plataform = "Nenhum";
            CreatedAt = DateTime.UtcNow;
        }
    }

    public class SaleInventory
    {
        public string ProductId { get; set; }
        public string AdId { get; set; }
        public int QuantitySold { get; set; }
        public double UnitaryPrice { get; set; }
        public List<SaleIncludedService> IncludedServices { get; set; }
        public List<SaleIncludedTax> Taxes { get; set; }
        public double TotalValue { get; set; }
        public SaleInventoryStates States { get; set; }
        public SaleInventory()
        {
            IncludedServices = new List<SaleIncludedService>();
            Taxes = new List<SaleIncludedTax>();
            UnitaryPrice = 0.00;
            TotalValue = 0.00;
            States = new SaleInventoryStates();
        }
    }

    public class SaleInventoryStates
    {
        public bool UnitaryPriceWasOverridden { get; set; } = false;
    }
        
    public class SaleIncludedService
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
    }

    public class SaleIncludedTax
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Percentage { get; set; }
    }

    public class BuyerData
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Address { get; set; }
    }

    //TODO
    public enum SalePlataform
    {
        NotProvided,
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
        Returned,
        Invalid
    }
}
