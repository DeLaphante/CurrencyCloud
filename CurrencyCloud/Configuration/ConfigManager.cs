﻿using Microsoft.Extensions.Configuration;
using System;

namespace CurrencyCloud.Configuration
{
    public class ConfigManager
    {
        static IConfiguration _Configuration { get; set; }

        static ConfigManager()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddUserSecrets<ConfigManager>(true, reloadOnChange: true);
            _Configuration = builder.Build();

        }

        public static string RS_User => _Configuration["RS_User"];
        public static string RS_Key => _Configuration["RS_Key"];
        public static string ApiKey => _Configuration["ApiKey"];
        public static string LoginId => _Configuration["Loginid"];

    }
}