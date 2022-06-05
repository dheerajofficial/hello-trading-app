using Microsoft.AspNetCore.Mvc;
using Trading.Models.Entities;
using Trading.Services.Dto;
using Trading.Services.Interfaces;

namespace Trading.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TradingAccountController : ControllerBase
{
    private readonly ILogger<TradingAccountController> _logger;
    private ITradingServices _tradingServices;

    public TradingAccountController(ILogger<TradingAccountController> logger, ITradingServices tradingServices)
    {
        _logger = logger;
        _tradingServices = tradingServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetAccountsAsync()
    {
        await Task.FromResult(0);
        var response = _tradingServices.GetAsync();        
        return Ok(response.Result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTradingAccountAsync(TradingAccountDto newAccount)
    {
        var response = await _tradingServices.CreateAsync(newAccount);
        if((response.Item1 == Guid.Empty) || (response.Item2 == Guid.Empty))
            return BadRequest(new { message = "Trading Account creation failed. Please contact admin." });
        return Ok(new TradingAccount() 
        { 
            Id = response.Item1, 
            InitialDeposit = newAccount.InitialDeposit, 
            Investor = response.Item2
        });
    }
}
       