using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Models.Product
{
    public class Product
    {
        public string Id { get; set; }
        // no update
        public string Name { get; set; }
        // no update
        public string Sku { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public Mesuarment Mesuarments { get; set; }
        public Category Category { get; set; }
        public Product()
        {
            Mesuarments = new Mesuarment();
        }
    }

    public class Mesuarment
    {
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
    }

    public enum Category
    {
        // TODO
    }
}
