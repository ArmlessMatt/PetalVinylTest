
using Common.Infrastructure.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vinyl.Domain.Interfaces
{
    public interface IVinylDataService
    {
        ServiceResponse<int> GetTotalVinyls();
        Task<ServiceResponse<List<Models.Vinyl>>> GetVinylsByIndex(List<int> indexList);
    }
}
