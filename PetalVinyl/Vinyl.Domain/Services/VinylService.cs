using System;
using System.Collections.Generic;
using Common.Infrastructure.Models.Common;
using Vinyl.Domain.Interfaces;

namespace Vinyl.Domain.Services
{
    public class VinylService : IVinylService
    {
        private IVinylDataService dataService;
        public VinylService(IVinylDataService dataService)
        {
            this.dataService = dataService;
        }

        public ServiceResponse<List<Models.Vinyl>> GetRandomVinyls(int numberOfVinyls)
        {
            var totalVinylsResponse = dataService.GetTotalVinyls();
            if (!totalVinylsResponse.IsSucces)
            {
                return new ErrorResponse<List<Models.Vinyl>>(totalVinylsResponse.ErrorMessages);
            }

            Random rand = new Random();
            List<int> selectedRandomIndexes = new List<int>();
            int number;
            for (int i = 0; i < numberOfVinyls; i++)
            {
                do
                {
                    number = rand.Next(1, totalVinylsResponse.Response);
                } while (selectedRandomIndexes.Contains(number));
                selectedRandomIndexes.Add(number);
            }

            var randomVinyls = dataService.GetVinylsByIndex(selectedRandomIndexes).Result;
            if (!randomVinyls.IsSucces)
            {
                return new ErrorResponse<List<Models.Vinyl>>(randomVinyls.ErrorMessages);
            }

            return new SuccesResponse<List<Models.Vinyl>>(randomVinyls.Response);
        }
    }
}
