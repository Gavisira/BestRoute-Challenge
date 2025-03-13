using BestRoute.Database.Context;
using BestRoute.Database.Contracts;
using BestRoute.Models;
using Microsoft.EntityFrameworkCore;

namespace BestRoute.Database;

public class RouteRepository(ApplicationDbContext context) : IRouteRepository
{
    public async Task<IEnumerable<RouteEntity>> GetAllAsync()
        => await context.Routes.ToListAsync();

    public async Task<RouteEntity?> GetByIdAsync(int id)
        => await context.Routes.FindAsync(id);

    public async Task AddAsync(RouteEntity route)
    {
        await context.Routes.AddAsync(route);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(RouteEntity route)
    {
        context.Routes.Update(route);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var route = await context.Routes.FindAsync(id);
        if (route is null) return;
        context.Routes.Remove(route);
        await context.SaveChangesAsync();
    }
}
