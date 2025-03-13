namespace BestRoute.Models
{
    public class RouteEntity
    {
        public int Id { get; set; }
        public string Origin { get; set; } = null!;
        public string Destination { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
