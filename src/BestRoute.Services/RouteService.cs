using BestRoute.Database.Contracts;
using BestRoute.Services.Contracts;

namespace BestRoute.Services;

public class RouteService(IRouteRepository routeRepository) : IRouteService
{
    public async Task<(List<string> path, decimal cost)> FindCheapestRouteAsync(string origin, string destination)
    {
        var routes = await routeRepository.GetAllAsync();

        var graph = routes
            .GroupBy(r => r.Origin)
            .ToDictionary(g => g.Key, g => g.Select(r => (r.Destination, r.Price)).ToList());

        var queue = new PriorityQueue<(string city, List<string> path, decimal cost), decimal>();
        queue.Enqueue((origin, new List<string> { origin }, 0), 0);

        var visited = new HashSet<string>();

        while (queue.Count > 0)
        {
            var (currentCity, currentPath, currentCost) = queue.Dequeue();

            if (currentCity == destination)
                return (currentPath, currentCost);

            if (visited.Contains(currentCity))
                continue;

            visited.Add(currentCity);

            if (!graph.ContainsKey(currentCity))
                continue;

            foreach (var (nextCity, price) in graph[currentCity])
            {
                var newPath = new List<string>(currentPath) { nextCity };
                var newCost = currentCost + price;

                queue.Enqueue((nextCity, newPath, newCost), newCost);
            }
        }

        throw new Exception("Route not found");
    }
}
