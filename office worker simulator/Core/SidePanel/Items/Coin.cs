namespace office_worker_simulator.Core.SidePanel.Items;

public class Coin
{
    public int CoinCounter { get; private set; }
    public int ExtraCoins { get; set; }
    
    public void AddCoins(int value) => CoinCounter += value;
}