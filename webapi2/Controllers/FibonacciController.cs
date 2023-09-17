using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("fibonacci")]
public class FibonacciController : ControllerBase
{

    private readonly ILogger<FibonacciController> _logger;

    public FibonacciController(ILogger<FibonacciController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("get")]
    public IEnumerable<Fibonacci> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Fibonacci
        {
            //    NTerm: Random.Shared.Next(-20, 55)
            //    Value:Random.Shared.Next(-20, 55)
        })
        .ToArray();
    }
}
