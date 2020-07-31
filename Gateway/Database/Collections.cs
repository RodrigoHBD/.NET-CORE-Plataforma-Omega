﻿using Gateway.ServerGrid.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway
{
    public class Collections
    {
        public static IMongoCollection<Platform> Platforms { get; set; }

        public static IMongoCollection<MLNotification> MLNotifications { get; set; }
  
        public static async Task InitializeAsync()
        {
            InitializeServerCollections();
            InitializeCommonCollections();
        }

        private static void InitializeServerCollections()
        {
            MLNotifications = Database.ServerConnection.GetCollection<MLNotification>("ML-Notifications");
        }

        private static void InitializeCommonCollections()
        {
            Platforms = Database.CommonConnection.GetCollection<Platform>("Platforms");
        }

    }
}
