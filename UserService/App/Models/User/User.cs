using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.App.Models
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{Name} {LastName}"; } }
        public DateTime CreatedAt { get; set; }
        public DateTime PasswordLastUpdatedAt { get; set; }
    }

}
