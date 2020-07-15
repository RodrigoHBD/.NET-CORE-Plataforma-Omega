
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.App
{
    public class ConstantMetadata
    {
        private static AppMetadata Data { get; set; } 

        public static AppMetadata GetInstance()
        {
            if(Data == null)
            {
                InitializeData();
            }
            return Data;
        }

        private static void InitializeData()
        {
            Data = new AppMetadata()
            {
                Uris = new AppUris()
                {
                    BaseUri = "https://plataforma-omega.brazilsouth.cloudapp.azure.com"
                }
            };
        }
    }

    public class AppMetadata
    {
        public AppUris Uris { get; set; } 
    }

    public class AppUris
    {
        public string BaseUri { get; set; }
    }
}
