
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Vinyl.Data.Models.Discogs
{
    public class DiscogsResponse
    {
        [JsonProperty("pagination")]
        public DiscogsPaginationInfo PaginationInfo { get; set; }

        [JsonProperty("releases")]
        public List<DiscogsRelease> Releases { get; set; }
    }
}
