using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("fibonacci")]
public class FibonacciController : ControllerBase
{
    private List<Int128> storedData = new List<Int128>();
    private readonly ILogger<FibonacciController> _logger;

    public FibonacciController(ILogger<FibonacciController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("get")]
    public List<Fibonacci> Get(int fn)
    {
        List<Fibonacci> fibonacci = new List<Fibonacci>();
        storedData = new List<Int128>();

        if (fn <= 0 || fn > 180)
        {
            return fibonacci;
        }

        storedData.Add(1);
        if (fn > 1)
        {
            storedData.Add(1);
        }

        if (fn > 2)
        {
            for (int i = 2; i < fn; i++)
            {
                Int128 nextValue = storedData[i - 1] + storedData[i - 2];
                storedData.Add(nextValue);
            }
        }

        int start = fn - 5;
        if (start < 0) start = 0;
        for (int i = start; i < fn; i++)
        {
            Fibonacci temp = new Fibonacci();
            temp.NTerm = i + 1;
            temp.Value = storedData[i].ToString("N0");

            fibonacci.Add(temp);
        }

        return fibonacci;
    }
}
