
using Common.Infrastructure.Models.Common;
using System.Collections.Generic;

namespace Vinyl.Domain.Interfaces
{
    interface IVinylDataService
    {
        ServiceResponse<int> GetTotalVinyls();
        ServiceResponse<List<Models.Vinyl>> GetVinylsByIndex(int index);
    }
}
