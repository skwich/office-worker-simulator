using office_worker_simulator.Core.Services.SidePanel;

namespace office_worker_simulator.Core.SidePanel.Buttons;

public class Button2 : Button
{
    public override int Price => 65;
    protected override int PassiveIncome => 5;

    public Button2(CoinService coinService) : base(coinService)
    {
    }
}