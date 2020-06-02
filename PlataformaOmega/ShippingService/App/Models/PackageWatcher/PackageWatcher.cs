using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models
{
    public class PackageWatcher
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string PackageId { get; set; }
        public string TrackingCode { get; set; }
        public DateTime LastCheckedAt { get; set; }
    }
}
