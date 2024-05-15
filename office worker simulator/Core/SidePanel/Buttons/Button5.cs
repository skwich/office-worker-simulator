using office_worker_simulator.Core.Services.SidePanel;

namespace office_worker_simulator.Core.SidePanel.Buttons;

public class Button5 : Button
{
    public override int Price => 500;
    protected override int PassiveIncome => 150;

    public Button5(CoinService coinService) : base(coinService)
    {
    }
}