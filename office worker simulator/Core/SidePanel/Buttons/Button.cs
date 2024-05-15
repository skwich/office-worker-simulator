using System;
using office_worker_simulator.Core.Services.SidePanel;

namespace office_worker_simulator.Core.SidePanel.Buttons;

public abstract class Button
{
    private bool IsLocked { get; set; }
    public virtual int Price => 30;
    protected virtual int PassiveIncome => 1;
    private readonly CoinService coinService;

    protected Button(CoinService coinService)
    {
        this.coinService = coinService;
    }
    
    public virtual void BuyWorker()
    {
        IsLocked = coinService.Coin.CoinCounter >= Price;
        if (IsLocked)
        {
            coinService.Coin.ExtraCoins += PassiveIncome;
            coinService.AddCoins(-Price);
        }
    }
}