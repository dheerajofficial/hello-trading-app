using Trading.Models.Entities;
using Trading.Services.Dto;

namespace Trading.Services.Interfaces;

public interface ITradingServices
{
    Task<Tuple<Guid,Guid>> CreateAsync(TradingAccountDto newAccount);
    Task<List<TradingAccountDto>> GetAsync();
}