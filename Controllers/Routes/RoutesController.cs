using BestRoute.Database.Contracts;
using BestRoute.Models;
using Microsoft.AspNetCore.Mvc;


namespace BestRoute.Controllers.Routes;

[ApiController]
[Route("api/routes")]
public class RoutesController(IRouteRepository routeRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await routeRepository.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Post(RouteEntity route)
    {
        await routeRepository.AddAsync(route);
        return CreatedAtAction(nameof(Get), new { id = route.Id }, route);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, RouteEntity route)
    {
        var existingRoute = await routeRepository.GetByIdAsync(id);
        if (existingRoute is null) return NotFound();

        existingRoute.Origin = route.Origin;
        existingRoute.Destination = route.Destination;
        existingRoute.Price = route.Price;

        await routeRepository.UpdateAsync(existingRoute);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await routeRepository.DeleteAsync(id);
        return NoContent();
    }
}
