using System;
using Trading.Services.Dto;
using Trading.Services.Interfaces;
using Trading.Services.Services;
namespace trading.services.Tests;

public class UnitTest_TradingServices
{    
    public readonly Mock<ITradingServices> _tradingServicesMock = new();
   
    [Fact]
    public async void TradingService_IsTradingAccountCreated()
    {        
        //arrange
        var ta = new TradingServices();
        var ta_new = new TradingAccountDto()
        {
            InitialDeposit = 500,
            Name = "Dheeraj",
            Address = "Bangalore, India"
        };

        //act
        var response = await ta.CreateAsync(ta_new);

        // Assert
        Assert.NotNull(response.Item1);
        Assert.NotNull(response.Item2);
    }
   
}