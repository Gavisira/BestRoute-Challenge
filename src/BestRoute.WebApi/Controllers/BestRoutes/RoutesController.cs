using BestRoute.Database.Contracts;
using BestRoute.Models;
using Microsoft.AspNetCore.Mvc;


namespace BestRoute.Controllers.Routes;

[ApiController]
[Route("api/[Controller]")]
public class RoutesController(IRouteRepository routeRepository) : ControllerBase
{
    /// <summary>
    /// Get all routes
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await routeRepository.GetAllAsync());


    /// <summary>
    /// Get a route by id
    /// </summary>
    /// <param name="route"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post(RouteEntity route)
    {
        await routeRepository.AddAsync(route);
        return CreatedAtAction(nameof(Get), new { id = route.Id }, route);
    }

    /// <summary>
    /// Update a route
    /// </summary>
    /// <param name="id"></param>
    /// <param name="route"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Delete a route
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await routeRepository.DeleteAsync(id);
        return NoContent();
    }
}
