namespace BestRoute.Services.Contracts
{
    public interface IRouteService
    {
        Task<(List<string> path, decimal cost)> FindCheapestRouteAsync(string origin, string destination);
    }
}
