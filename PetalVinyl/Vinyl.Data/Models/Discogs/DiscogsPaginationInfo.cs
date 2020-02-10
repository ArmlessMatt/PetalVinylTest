
using Newtonsoft.Json;

namespace Vinyl.Data.Models.Discogs
{
    public class DiscogsPaginationInfo
    {
        [JsonProperty("name")]
        public int ElementsPerPage { get; set; }

        [JsonProperty("name")]
        public int NumberOfElements { get; set; }
    }
}
