using Service.API.ERP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.API.ERP.Interface
{
    public interface IConnect : IDisposable
    {
        Task<ExistRequest> GetExistRescue(long rescue);

        Task<RequestReturn> AddRequest(Request request);

        Task<Tracking> GetTracking(long rescue);
    }
}
