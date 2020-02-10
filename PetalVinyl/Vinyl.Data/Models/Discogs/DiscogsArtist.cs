using Newtonsoft.Json;

namespace Vinyl.Data.Models.Discogs
{
    public class DiscogsArtist
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
