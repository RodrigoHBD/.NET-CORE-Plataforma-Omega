using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace ShippingService.App.Models
{
    public class Package
    {
        [BsonId]
        public ObjectId Id { get; set; } 

        public string Name { get; set; } = "";

        public int WeightInGrams { get; set; }

        public PackageContent Content { get; set; } = new PackageContent();

        public PackageDates Dates { get; set; } = new PackageDates();

        public PackageMeasurement Measurement { get; set; } = new PackageMeasurement();
    }

}
