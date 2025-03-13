using BestRoute.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BestRoute.Controllers.Routes;

[ApiController]
[Route("api/bestroute")]
public class BestRouteController(IRouteService routeService) : ControllerBase
{
    [HttpGet("{origin}-{destination}")]
    public async Task<IActionResult> GetBestRoute(string origin, string destination)
    {
        try
        {
            var (path, cost) = await routeService.FindCheapestRouteAsync(origin, destination);
            return Ok(new { route = string.Join(" - ", path), cost });
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
