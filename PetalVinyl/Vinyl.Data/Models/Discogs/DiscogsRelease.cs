
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Vinyl.Data.Models.Discogs
{
    public class DiscogsRelease
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("artists")]
        public List<DiscogsArtist> Artists { get; set; }
    }
}
