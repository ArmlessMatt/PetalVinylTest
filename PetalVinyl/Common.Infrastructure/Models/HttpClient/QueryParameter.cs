namespace Common.Infrastructure.Models
{
    public class QueryParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Name + "=" + Value;
        }
    }
}
