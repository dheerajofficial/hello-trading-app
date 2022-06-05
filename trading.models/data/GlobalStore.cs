using System.Collections.Concurrent;
using Trading.Models.Entities;

namespace Trading.Models.Data;

public static class GlobalStore
{
    static GlobalStore()
    {
        TradingAccountStore = new ConcurrentDictionary<Guid, TradingAccount>();
        InvestmentStore = new ConcurrentDictionary<Guid, Investment>();
        InvestorStore = new ConcurrentDictionary<Guid, Investor>();
        InstitutionStore = new ConcurrentDictionary<Guid, Institution>();
    }
    public static ConcurrentDictionary<Guid, TradingAccount> TradingAccountStore { get; set; }
    public static ConcurrentDictionary<Guid, Investment> InvestmentStore { get; set; }
    public static ConcurrentDictionary<Guid, Investor> InvestorStore { get; set; }
    public static ConcurrentDictionary<Guid, Institution> InstitutionStore { get; set; }
}