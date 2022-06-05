namespace Trading.Models.Entities;

public class Investment
{
    public Guid Id { get; set; }
    public Guid TradingAccount { get; set; }
    public string? Currency { get; set; }
    public double Amount { get; set; }
    public Guid Institution { get; set; }
}