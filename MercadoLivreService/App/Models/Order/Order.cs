using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.Models
{
    public class Order
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int MercadoLivreId { get; set; }
        public string Status { get; set; }
        public string StatusDetail { get; set; }
        public List<OrderItemWrapper> Items { get; set; }
        public double TotalAmmount { get; set; }
        public string CurrencyId { get; set; }
    }

    public class OrderItemWrapper
    {
        public OrderItem Item { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderItem
    {
        public string MercadoLivreId { get; set; }
        public string Title { get; set; }
    }

    public class OrderPayment
    {

    }
}
