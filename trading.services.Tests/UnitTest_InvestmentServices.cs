using System;
using Trading.Services.Dto;
using Trading.Services.Interfaces;
using Trading.Services.Services;
namespace trading.services.Tests;

public class UnitTest_InvestmentServices
{    
    public readonly Mock<IInvestmentServices> _investmentServicesMock = new();  
   
    [Fact]
    public async void InvestmentServices_IsInvestmentAdded()
    {
        //arrange
        SeedData.Initialize();
        var investmentServices = new InvestmentServices();
        var t_id = investmentServices.GetDtoAsync().Result.Select(x => new { x.TradingAccount }).Take(1).Single().TradingAccount;
        var i_new = new InvestmentDto()
        {
            Id = Guid.NewGuid(),
            TradingAccount = t_id,
            Currency = "SGD",
            InstitutionName = "apple",
            Amount = 1000
        };

        //act
        var response = await investmentServices.CreateAsync(i_new);

        // Assert
        Assert.NotNull(response);
    }
   
}