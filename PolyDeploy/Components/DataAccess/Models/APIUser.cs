﻿using DotNetNuke.ComponentModel.DataAnnotations;
using System;

namespace Cantarus.Modules.PolyDeploy.Components.DataAccess.Models
{
    [TableName("Cantarus_PolyDeploy_APIUsers")]
    [PrimaryKey("APIUserID")]
    internal class APIUser
    {
        public int APIUserId { get; set; }
        public string Name { get; set; }
        public string APIKey { get; set; }
        public string EncryptionKey { get; set; }
        public bool BypassIPWhitelist { get; set; }

        public APIUser() { }

        public APIUser(string name, bool bypass)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new Exception("Unable to create new APIUser without a name.");
            }

            Name = name;
            BypassIPWhitelist = bypass;
            APIKey = GenerateKey();
            EncryptionKey = GenerateKey();
        }

        private static string GenerateKey()
        {
            // Get new guid as string.
            string guidString = Guid.NewGuid().ToString();

            // Remove hyphens, uppercase and return.
            return guidString.Replace("-", null).ToUpper();
        }
    }
}
