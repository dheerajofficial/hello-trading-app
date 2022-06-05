using Trading.Models.Data;
using Trading.Models.Entities;
public static class SeedData
{
    public static void Initialize()
    {
        var rand = new Random(500);
        Guid[] taccs = new Guid[4];
        Guid[] insts = new Guid[4];
        int i = 0;
        var tacc = new List<TradingAccount>();

        //Institution
        var inst = new List<Institution>
        {
            new Institution{ Id=Guid.NewGuid(),Name="google", Sym="GOGL"},
            new Institution{ Id=Guid.NewGuid(),Name="microsoft", Sym="MSFT"},
            new Institution{ Id=Guid.NewGuid(),Name="apple", Sym="APPL"}
        };
        foreach(var item in inst)
        {           
            insts[i] = item.Id;
            GlobalStore.InstitutionStore.TryAdd(item.Id,item);
            i++;
        }
        //Investor
        var investors = new List<Investor>
        {
            new Investor{ Id=Guid.NewGuid(), Name="Alex", Address="California,USA"},
            new Investor{ Id=Guid.NewGuid(), Name="John", Address="London,UK"},
            new Investor{ Id=Guid.NewGuid(), Name="Marie", Address="Berlin, Germany"},
            new Investor{ Id=Guid.NewGuid(), Name="Mark", Address="Dublin, Ireland"}
        };

        //TradingAccount
        i = 0;
        foreach (var investor in investors)
        {
            var id = Guid.NewGuid();           
            var ta = new TradingAccount() { Id = id, InitialDeposit = rand.Next(100, 1000), Investor = investor.Id };
            tacc.Add(ta);
            taccs[i] = id;
            GlobalStore.InvestorStore.TryAdd(investor.Id, investor);
            GlobalStore.TradingAccountStore.TryAdd(ta.Id, ta);
            i++;
        }

        //investments
        var investments = new List<Investment>
        {
            new Investment{Id=Guid.NewGuid(), Amount=rand.Next(200,600), Currency="USD", TradingAccount=taccs[0], Institution=insts[0]},
            new Investment{Id=Guid.NewGuid(), Amount=rand.Next(200,600), Currency="JPY", TradingAccount=taccs[0], Institution=insts[1]},
            new Investment{Id=Guid.NewGuid(), Amount=rand.Next(200,600), Currency="USD", TradingAccount=taccs[0], Institution=insts[1]},
            new Investment{Id=Guid.NewGuid(), Amount=rand.Next(200,600), Currency="EUR", TradingAccount=taccs[0], Institution=insts[2]},
            new Investment{Id=Guid.NewGuid(), Amount=rand.Next(200,600), Currency="USD", TradingAccount=taccs[0], Institution=insts[2]},
            //
            new Investment{Id=Guid.NewGuid(), Amount=rand.Next(200,600), Currency="USD", TradingAccount=taccs[1], Institution=insts[0]},
            new Investment{Id=Guid.NewGuid(), Amount=rand.Next(200,600), Currency="JPY", TradingAccount=taccs[1], Institution=insts[1]},
            new Investment{Id=Guid.NewGuid(), Amount=rand.Next(200,600), Currency="USD", TradingAccount=taccs[1], Institution=insts[1]},
            new Investment{Id=Guid.NewGuid(), Amount=rand.Next(200,600), Currency="EUR", TradingAccount=taccs[1], Institution=insts[2]},
            new Investment{Id=Guid.NewGuid(), Amount=rand.Next(200,600), Currency="USD", TradingAccount=taccs[1], Institution=insts[2]},
            //
            new Investment{Id=Guid.NewGuid(), Amount=rand.Next(200,600), Currency="USD", TradingAccount=taccs[2], Institution=insts[0]},
            new Investment{Id=Guid.NewGuid(), Amount=rand.Next(200,600), Currency="JPY", TradingAccount=taccs[2], Institution=insts[1]},
            new Investment{Id=Guid.NewGuid(), Amount=rand.Next(200,600), Currency="USD", TradingAccount=taccs[2], Institution=insts[1]},
            new Investment{Id=Guid.NewGuid(), Amount=rand.Next(200,600), Currency="EUR", TradingAccount=taccs[2], Institution=insts[2]},
            new Investment{Id=Guid.NewGuid(), Amount=rand.Next(200,600), Currency="USD", TradingAccount=taccs[2], Institution=insts[2]}
        };
        foreach(var item in investments)
        {
            GlobalStore.InvestmentStore.TryAdd(item.Id, item);
        }       
    }
}
