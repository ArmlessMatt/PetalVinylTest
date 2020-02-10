
using Common.Infrastructure.Models.Common;
using System.Collections.Generic;

namespace Vinyl.Domain.Interfaces
{
    public interface IVinylService
    {
        ServiceResponse<List<Models.Vinyl>> GetRandomVinyls(int numberOfVinyls);
    }
}
