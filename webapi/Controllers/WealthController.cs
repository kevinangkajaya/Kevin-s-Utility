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
    public IActionResult Get()
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

        return Ok(wealth);
    }

    [HttpGet]
    [Route("get/{ID}")]
    public IActionResult GetByID(int ID)
    {
        Wealth temp = new Wealth();
        temp.ID = ID;
        temp.Location = "Tokocrypto";
        temp.Sublocation = "ETH";
        temp.Active = true;
        double x = 0.43534;
        double y = 76876.276;
        temp.Value = x;
        temp.ValueInRupiah = y;

        return Ok(temp);
    }

    [HttpPost]
    [Route("new")]
    public IActionResult New(Wealth wealth)
    {
        string errMsg = "";
        if (wealth.Location == "")
        {
            errMsg = "Location is required";
        }
        else if (wealth.Sublocation == "")
        {
            errMsg = "Sub Location is required";
        }

        if (errMsg != "")
        {
            return BadRequest(errMsg);
        }

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
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

        return Ok();
    }

    [HttpPut]
    [Route("update")]
    public IActionResult Update(Wealth wealth)
    {
        string errMsg = "";
        if (wealth.ID == 0)
        {
            errMsg = "ID is required";
        }
        else if (wealth.Location == "")
        {
            errMsg = "Location is required";
        }
        else if (wealth.Sublocation == "")
        {
            errMsg = "Sub Location is required";
        }

        if (errMsg != "")
        {
            return BadRequest(errMsg);
        }

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
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

        return Ok();
    }

    [HttpDelete]
    [Route("delete/{ID}")]
    public IActionResult Delete(int ID)
    {
        string errMsg = "";
        if (ID == 0)
        {
            errMsg = "ID is required";
        }

        if (errMsg != "")
        {
            return BadRequest(errMsg);
        }

        try
        {

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

        return Ok();
    }
}
