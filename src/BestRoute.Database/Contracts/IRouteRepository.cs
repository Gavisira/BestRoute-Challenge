using BestRoute.Models;

namespace BestRoute.Database.Contracts
{
    public interface IRouteRepository
    {
        Task<IEnumerable<RouteEntity>> GetAllAsync();
        Task<RouteEntity?> GetByIdAsync(int id);
        Task AddAsync(RouteEntity route);
        Task UpdateAsync(RouteEntity route);
        Task DeleteAsync(int id);
    }
}
