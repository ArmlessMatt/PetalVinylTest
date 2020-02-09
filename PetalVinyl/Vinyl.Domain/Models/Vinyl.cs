using System.Collections.Generic;

namespace Vinyl.Domain.Models
{
    public class Vinyl
    {
        public string Title { get; set; }
        public List<string> Artists { get; private set; }

        public Vinyl()
        {
            Artists = new List<string>();
        }
    }
}
