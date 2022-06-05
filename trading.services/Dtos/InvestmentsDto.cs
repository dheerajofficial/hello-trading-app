namespace Trading.Services.Dto;

public class InvestmentDto
{
    public Guid Id { get; set; }
    public Guid TradingAccount { get; set; }
    public string? Currency { get; set; }
    public double Amount { get; set; }
    public string? InstitutionName { get; set; }
}