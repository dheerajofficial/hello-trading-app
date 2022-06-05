using Microsoft.AspNetCore.Mvc;
using Trading.Services.Dto;
using Trading.Services.Interfaces;
namespace Trading.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvestmentController : ControllerBase
{
    private readonly ILogger<InvestmentController> _logger;
    private IInvestmentServices _investmentServices;

    public InvestmentController(ILogger<InvestmentController> logger, IInvestmentServices investmentServices)
    {
        _logger = logger;
        _investmentServices = investmentServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetAccountsAsync()
    {
        await Task.FromResult(0);
        var response = _investmentServices.GetDtoAsync();

        return Ok(response.Result);
    }

    [HttpGet("{tradingAccount}/balance")]
    public async Task<IActionResult> GetAccountBalanceAsync(Guid tradingAccount)
    {
        await Task.FromResult(0);
        var response = _investmentServices.GetAccountBalance(tradingAccount);
        return Ok(new { TradingAccount = tradingAccount, AccountBalance = response.Result });
    }

    [HttpPost("{tradingAccount}")]
    public async Task<IActionResult> AddInvestmentAsync(InvestmentDto newAccount, Guid tradingAccount)
    {
        newAccount.TradingAccount = tradingAccount;
        var id = await _investmentServices.CreateAsync(newAccount);

        if (id != Guid.Empty)
        {
            var investments = _investmentServices.GetDtoAsync();
            foreach (var item in investments.Result)
            {
                if (item.Id == id)
                {
                    return Ok(item);
                }
            }
        }
        return BadRequest(new { message = "Opps! something went wrong." });
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(string? currency="",double? amount=0, string? institutionName="")
    {
        await Task.FromResult(0); 
        List<InvestmentDto> investments = new List<InvestmentDto>();
        var serviceResponse = _investmentServices.GetDtoAsync().Result;
        if(!string.IsNullOrEmpty(currency))
        {
            var r = serviceResponse.Where(c => c.Currency == currency.ToUpper());
            investments.AddRange(r);
        }
        if (amount > 0)
        {
            var r = serviceResponse.Where(c => c.Amount == amount);
            investments.AddRange(r);
        }
        if(!string.IsNullOrEmpty(institutionName))
        {
            var id = await _investmentServices.GetInstitutionByNameAsync(institutionName);
            var r = serviceResponse.Where(c => c.InstitutionName == institutionName);
            investments.AddRange(r);
        }
        return Ok(investments);
    }
}
