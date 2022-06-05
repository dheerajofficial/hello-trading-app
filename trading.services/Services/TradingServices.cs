using Trading.Models.Data;
using Trading.Models.Entities;
using Trading.Services.Dto;
using Trading.Services.Interfaces;
namespace Trading.Services.Services;

public class TradingServices : ITradingServices
{
    public async Task<Tuple<Guid,Guid>> CreateAsync(TradingAccountDto newAccount)
    {
        await Task.FromResult(0);
        Guid t_acc_id = Guid.NewGuid();
        Guid investor_id = Guid.NewGuid();
        bool result = false;

        var _investor = new Investor()
        {
            Id = investor_id,
            Name = newAccount.Name,
            Address = newAccount.Address
        };

        var isInvestorAdded = GlobalStore.InvestorStore.TryAdd(investor_id, _investor);
        if (isInvestorAdded == true)
        {
            var t_acc = new TradingAccount()
            {
                Id = t_acc_id,
                InitialDeposit = newAccount.InitialDeposit,
                Investor = investor_id
            };

            result = GlobalStore.TradingAccountStore.TryAdd(t_acc_id, t_acc);
        }
        
        if(result) return Tuple.Create(t_acc_id,investor_id);
        else return Tuple.Create(Guid.Empty,Guid.Empty);

    }

    public async Task<List<TradingAccountDto>> GetAsync()
    {
        await Task.FromResult(0);
        List<TradingAccountDto> tradingAccounts = new List<TradingAccountDto>();
        foreach (var item in GlobalStore.TradingAccountStore)
        {
            var investor = GetInvestorInfo(item.Value.Investor);
            var ta_dto = new TradingAccountDto()
            {
                TradingAccountId = item.Value.Id,
                InvestorId = item.Value.Investor,
                InitialDeposit = item.Value.InitialDeposit,
                Name = investor.Item1,
                Address = investor.Item2
            };
            tradingAccounts.Add(ta_dto);
        }
        return tradingAccounts;
    }

    
    private Tuple<string?,string?> GetInvestorInfo(Guid investor_id)
    {
        var investor_info = GlobalStore.InvestorStore.Where(i => i.Key == investor_id).Select(x=> new { x.Value.Name, x.Value.Address}).Single();
        return Tuple.Create(investor_info.Name, investor_info.Address);
    }

}