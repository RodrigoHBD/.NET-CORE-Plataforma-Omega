using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Models
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Type { get; protected set; }
        // no update
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public ProductCategory Category { get; set; }
        public string Brand { get; set; } = "";
        public string Model { get; set; } = "";
        public ProductColor Color { get; set; }
        public ProductWarranty Warranty { get; set; }
        public List<string> PicturesUrls { get; set; }
        public ProductCondition Condition { get; set; }

        public Product()
        {
            Category = ProductCategory.Invalid;
            Color = ProductColor.Invalid;
            Warranty = new ProductWarranty();
            PicturesUrls = new List<string>();
            Condition = ProductCondition.Invalid;
            Type = "BaseClass";
        }

    }
    

    // cross doc == tempo de envio lead time // Ad related ** CONFIGURÁVEL

    // preço fake // não pode ser (29% > preço real // 29% < preço real) *CONFIGURÁVEL
    // Preço padrão
    // Preço por canal de venda // Ad related ?

    // descontos *CONFIGURÁVEL

    // Quantidade por caixa

    // Código de barras

    public class ProductWarranty
    {
        // months
        public int TimeInDays { get; set; } = 0;
    }

    public enum ProductCategory
    {
        // TODO
        Teste,
        Invalid
    }

    public enum ProductColor
    {
        Black,
        White,
        Invalid
    }

    public enum ProductCondition
    {
        New,
        Used,
        Invalid
    }

}
