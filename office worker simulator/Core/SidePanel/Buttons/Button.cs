using System;
using office_worker_simulator.Core.Services.SidePanel;

namespace office_worker_simulator.Core.SidePanel.Buttons;

public class Button
{
    private bool IsLocked { get; set; }
    public int Price { get; }
    private int PassiveIncome { get; }
    private readonly CoinService coinService;

    public Button(CoinService coinService, int price, int passiveIncome)
    {
        this.coinService = coinService;
        Price = price;
        PassiveIncome = passiveIncome;
    }
    
    public void BuyWorker()
    {
        IsLocked = coinService.Coin.CoinCounter >= Price;
        if (IsLocked)
        {
            coinService.Coin.ExtraCoins += PassiveIncome;
            coinService.AddCoins(-Price);
        }
    }
}