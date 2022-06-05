namespace Trading.Models.Entities;

public class TradingAccount
{
    public Guid Id { get; set; }
    public Guid Investor { get; set; }
    public double InitialDeposit { get; set; }
}
