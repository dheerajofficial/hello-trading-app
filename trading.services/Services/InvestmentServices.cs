using Trading.Models.Data;
using Trading.Models.Entities;
using Trading.Services.Dto;
using Trading.Services.Interfaces;
namespace Trading.Services.Services;

public class InvestmentServices : IInvestmentServices
{
    public async Task<Guid> CreateAsync(InvestmentDto newAccount)
    {
        Guid instId = await GetInstitutionByNameAsync(newAccount.InstitutionName);
        var investment = new Investment()
        {
            Id=Guid.NewGuid(),
            TradingAccount= newAccount.TradingAccount,
            Currency = newAccount.Currency,
            Amount = newAccount.Amount,
            Institution = instId
        };
        //add investment
       bool result = GlobalStore.InvestmentStore.TryAdd(investment.Id, investment);
       if(result) return investment.Id;
       else return Guid.Empty;
    }

    public async Task<List<Investment>> GetAsync()
    {
        await Task.FromResult(0);
        List<Investment> investments = new List<Investment>();
        foreach (var item in GlobalStore.InvestmentStore)
        {
            investments.Add(item.Value);
        }
        return investments;
    }
    public async Task<List<InvestmentDto>> GetDtoAsync()
    {
        await Task.FromResult(0);
        List<InvestmentDto> investments = new List<InvestmentDto>();
        foreach (var item in GlobalStore.InvestmentStore)
        {   
            var _dto = new InvestmentDto()
            {
                Id = item.Value.Id,
                TradingAccount = item.Value.TradingAccount,
                Currency = item.Value.Currency,
                Amount = item.Value.Amount,
                InstitutionName = await GetInstitutionNameByIdAsync(item.Value.Institution)
            };
            investments.Add(_dto);
        }
    
        return investments;
    }
    public async Task<double> GetAccountBalance(Guid id)
    {
        await Task.FromResult(0);
        double balance = 0;

        foreach(var item in GlobalStore.InvestmentStore)
        {
            if(item.Value.TradingAccount == id) balance += item.Value.Amount;
        }
        return balance;
    }
    public async Task<Guid> GetInstitutionByNameAsync(string? instName)
    {
        await Task.FromResult(0);
        return GlobalStore.InstitutionStore.Where(c => c.Value.Name == instName?.ToLower()).Select(x => new { x.Value.Id }).Single().Id;
    }
    private async Task<string> GetInstitutionNameByIdAsync(Guid instId)
    {
        await Task.FromResult(0);
        var _name = GlobalStore.InstitutionStore.Where(c => c.Value.Id == instId).Select(x => new { x.Value.Name }).Single().Name;
        if(_name is not null) return _name;
        else return "";
    }
}