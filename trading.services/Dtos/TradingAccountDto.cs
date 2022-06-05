namespace Trading.Services.Dto;

public class TradingAccountDto
{
    public Guid TradingAccountId { get; set; }
    public Guid InvestorId { get; set; }
    public double InitialDeposit { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
}