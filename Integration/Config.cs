using Microsoft.Extensions.Configuration;
using Service.API.ERP.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Service.API.ERP.Integration
{
    public class Config : IConfig
    {
        private string _url { get; set; }

        private string _token { get; set; }

        private string _user { get; set; }

        private string _password { get; set; }

        public Config()
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _url = config.GetSection("ERPConnection:Url").Value;
            _token = config.GetSection("ERPConnection:Token").Value;
            _user = config.GetSection("ERPConnection:User").Value;
            _password = config.GetSection("ERPConnection:Password").Value;
        }

        public string GetUrl()
        {
            return _url;
        }

        public string GetToken()
        {
            return _token;
        }

        public string GetUserName()
        {
            return _user;
        }

        public string GetPassword()
        {
            return _password;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
