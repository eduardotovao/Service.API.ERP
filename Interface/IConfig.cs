using System;
using System.Collections.Generic;
using System.Text;

namespace Service.API.ERP.Interface
{
    public interface IConfig : IDisposable
    {
        string GetUrl();
        string GetToken();
        string GetUserName();
        string GetPassword();
    }
}
