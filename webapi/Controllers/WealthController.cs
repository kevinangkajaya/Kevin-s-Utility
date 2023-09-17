using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("wealth")]
public class WealthController : ControllerBase
{
    private readonly ILogger<WealthController> _logger;

    public WealthController(ILogger<WealthController> logger)
    {
        _logger = logger;
    }


    [HttpGet]
    [Route("get")]
    public IEnumerable<Wealth> Get()
    {
        List<Wealth> wealth = new List<Wealth>();

        for (int i = 0; i < 5; i++)
        {
            Wealth temp = new Wealth();
            temp.ID = i + 1;
            temp.Location = "Tokocrypto";
            temp.Sublocation = "ETH";
            temp.Active = false;
            double x = 0.00856369;
            double y = 202052.276;
            temp.Value = x;
            temp.ValueInRupiah = y;

            wealth.Add(temp);
        }

        return wealth;
    }

    [HttpPost]
    [Route("new")]
    public bool New(Wealth wealth)
    {
        Wealth temp = new Wealth();
        try
        {
            temp.ID = 1;
            temp.Location = wealth.Location;
            temp.Sublocation = wealth.Sublocation;
            temp.Active = wealth.Active;
            temp.Value = wealth.Value;
            temp.ValueInRupiah = wealth.ValueInRupiah;
        }
        catch (Exception ex)
        {
            return false;
        }

        return true;
    }

    [HttpPut]
    [Route("update")]
    public bool Update(Wealth wealth)
    {
        try
        {
            Wealth temp = new Wealth();
            temp.ID = wealth.ID;
            temp.Location = wealth.Location;
            temp.Sublocation = wealth.Sublocation;
            temp.Active = wealth.Active;
            temp.Value = wealth.Value;
            temp.ValueInRupiah = wealth.ValueInRupiah;
        }
        catch (Exception ex)
        {
            return false;
        }

        return true;
    }

    [HttpDelete]
    [Route("delete/{ID}")]
    public bool Delete(int ID)
    {
        Console.WriteLine(ID);

        return true;
    }
}
