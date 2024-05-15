using office_worker_simulator.Core.SidePanel.Items;

namespace office_worker_simulator.Core.Services.SidePanel;

public class CoinService
{
    public readonly Coin Coin;

    public CoinService(Coin coin) => Coin = coin;

    public void AddCoins(int value) => Coin.AddCoins(value);
}