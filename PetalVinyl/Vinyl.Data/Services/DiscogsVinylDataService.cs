using System;
using System.Collections.Generic;
using System.Text;
using Common.Infrastructure.Interfaces;
using Common.Infrastructure.Models.Common;
using Vinyl.Domain.Interfaces;
using Vinyl.Domain.Models;

namespace Vinyl.Data.Services
{
    public class DiscogsVinylDataService : IVinylDataService
    {
        public DiscogsVinylDataService(IHttpClient httpClient)
        {

        }
        public ServiceResponse<int> GetTotalVinyls()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<List<Domain.Models.Vinyl>> GetVinylsByIndex(int index)
        {
            throw new NotImplementedException();
        }
    }
}
