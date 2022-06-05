# Trading App
dotnet dev-certs https --trust

https://localhost:7156/swagger/index.html


## create new sln and projects

`dotnet new sln --name=tradingapp`

`dotnet new webapi --name=trading.api`

`dotnet new classlib --name=trading.models`

`dotnet new classlib --name=trading.services`

## Packages:
	Swashbuckle
	xUnit
	Moq - dotnet add package Moq --version 4.18.1
	.NET Core Test Explorer

## xunit test project

`dotnet new xunit -o trading.services.Tests`


## add projects to sln

`dotnet sln tradingapp.sln add trading.api\trading.api.csproj`

`dotnet sln tradingapp.sln add trading.models\trading.models.csproj`

`dotnet sln tradingapp.sln add trading.services\trading.services.csproj`

`dotnet add trading.api\trading.api.csproj reference trading.models\trading.models.csproj`

## add swagger

> dotnet add TodoApi.csproj package Swashbuckle.AspNetCore -v 6.2.3

## running the project
> dotnet run --project trading.api\trading.api.csproj

## running the xunit test
> goes here

```
trading-account
	accId,invertorId,initialdeposit
	
investments
	investmentid,accId,currency,amounts,institutions
	
Investor
	investorId,name,address
	
institutions
	institutionId, name, symbol
```
trading.api - trading endpoints
	Controllers: TradingAccountController, InvestmentController

trading.services- crud operations


> SeedData.Initialize();

## Testing xUnit
	
> dotnet new xunit -o trading.services.Tests

> dotnet sln tradingapp.sln add trading.services.Tests\trading.services.Tests.csproj

> dotnet add trading.services.Tests\trading.services.Tests.csproj reference trading.services\trading.services.csproj
```
dotnet add trading.services.Tests\trading.services.Tests.csproj reference trading.models\trading.models.csproj
dotnet add trading.services.Tests\trading.services.Tests.csproj reference trading.services\trading.services.csproj

```