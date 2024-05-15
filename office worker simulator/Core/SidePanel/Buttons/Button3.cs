using office_worker_simulator.Core.Services.SidePanel;

namespace office_worker_simulator.Core.SidePanel.Buttons;

public class Button3 : Button
{
    public override int Price => 175;
    protected override int PassiveIncome => 20;

    public Button3(CoinService coinService) : base(coinService)
    {
    }
}