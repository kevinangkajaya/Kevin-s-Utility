using Microsoft.AspNetCore.Mvc;
using webapi.DbContext;
using webapi.services;

namespace webapi.Controllers;

[ApiController]
[Route("wealth")]
public class WealthController : ControllerBase
{
    private readonly ILogger<WealthController> _logger;
    private readonly IMariaDbWealthService _wealthService;

    public WealthController(ILogger<WealthController> logger, IMariaDbWealthService wealthService)
    {
        _logger = logger;
        _wealthService = wealthService;
    }


    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> Get()
    {
        IEnumerable<Wealth> wealths = await _wealthService.FindAll();

        return Ok(wealths);
    }

    [HttpGet]
    [Route("get/{ID}")]
    public async Task<IActionResult> GetByID(int ID)
    {
        Wealth temp = await _wealthService.FindOne(ID);

        return Ok(temp);
    }

    [HttpPost]
    [Route("new")]
    public async Task<IActionResult> New(Wealth incoming)
    {
        string errMsg = "";
        if (incoming.Location == "")
        {
            errMsg = "Location is required";
        }

        if (errMsg != "")
        {
            return BadRequest(errMsg);
        }

        try
        {
            Wealth temp = new Wealth();
            temp.UserID = 1; // foreign key
            temp.Location = incoming.Location;
            temp.Sublocation = incoming.Sublocation;
            temp.Active = incoming.Active;
            temp.Value = incoming.Value;
            temp.ValueInRupiah = incoming.ValueInRupiah;
            temp.CreatedAt = DateTime.Now;

            int result = await _wealthService.Insert(temp);
            if (result <= 0)
            {
                throw new Exception("Failed to insert data");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

        return Ok();
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> Update(Wealth incoming)
    {
        string errMsg = "";
        if (incoming.ID == 0)
        {
            errMsg = "ID is required";
        }
        else if (incoming.Location == "")
        {
            errMsg = "Location is required";
        }

        if (errMsg != "")
        {
            return BadRequest(errMsg);
        }

        try
        {
            Wealth temp = await _wealthService.FindOne(incoming.ID);

            temp.Location = incoming.Location;
            temp.Sublocation = incoming.Sublocation;
            temp.Active = incoming.Active;
            temp.Value = incoming.Value;
            temp.ValueInRupiah = incoming.ValueInRupiah;
            temp.UpdatedAt = DateTime.Now;

            int result = await _wealthService.Update(temp);
            if (result <= 0)
            {
                throw new Exception("Failed to update data");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

        return Ok();
    }

    [HttpDelete]
    [Route("delete/{ID}")]
    public async Task<IActionResult> Delete(int ID)
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
            Wealth temp = await _wealthService.FindOne(ID);
            temp.DeletedAt = DateTime.Now;

            int result = await _wealthService.Update(temp);
            if (result <= 0)
            {
                throw new Exception("Failed to delete data");
            }

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

        return Ok();
    }
}
