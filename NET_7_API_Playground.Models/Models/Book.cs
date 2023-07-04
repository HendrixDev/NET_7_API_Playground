using System.Text.Json.Serialization;

namespace NET_7_API_Playground.Entities.Models
{
    public class Book
    {
        [JsonIgnore]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
    }
}