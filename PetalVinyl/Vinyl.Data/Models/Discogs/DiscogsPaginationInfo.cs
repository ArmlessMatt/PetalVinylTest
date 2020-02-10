
using Newtonsoft.Json;

namespace Vinyl.Data.Models.Discogs
{
    public class DiscogsPaginationInfo
    {
        [JsonProperty("per_page")]
        public int ElementsPerPage { get; set; }

        [JsonProperty("items")]
        public int NumberOfElements { get; set; }
    }
}
