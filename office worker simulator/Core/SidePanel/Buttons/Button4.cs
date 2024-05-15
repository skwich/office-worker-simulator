using office_worker_simulator.Core.Services.SidePanel;

namespace office_worker_simulator.Core.SidePanel.Buttons;

public class Button4 : Button
{
    public override int Price => 300;
    protected override int PassiveIncome => 50;

    public Button4(CoinService coinService) : base(coinService)
    {
    }
}