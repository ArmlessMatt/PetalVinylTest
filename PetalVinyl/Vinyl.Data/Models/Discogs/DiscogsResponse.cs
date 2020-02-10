
using Newtonsoft.Json;

namespace Vinyl.Data.Models.Discogs
{
    public class DiscogsResponse
    {
        [JsonProperty("pagination")]
        public DiscogsPaginationInfo PaginationInfo { get; set; }
    }
}
