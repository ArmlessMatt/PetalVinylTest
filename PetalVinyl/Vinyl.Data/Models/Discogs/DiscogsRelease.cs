
using Newtonsoft.Json;

namespace Vinyl.Data.Models.Discogs
{
    public class DiscogsRelease
    {
        [JsonProperty("basic_information")]
        public DiscogsBasicInformation BasicInformation { get; set; }
    }
}
