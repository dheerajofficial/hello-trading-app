using Trading.Models.Entities;
using Trading.Services.Dto;

namespace Trading.Services.Interfaces;

public interface IInvestmentServices
{
    Task<Guid> CreateAsync(InvestmentDto newAccount);
    Task<List<Investment>> GetAsync();
    Task<List<InvestmentDto>> GetDtoAsync();
    Task<double> GetAccountBalance(Guid id);
    Task<Guid> GetInstitutionByNameAsync(string? instName);
}