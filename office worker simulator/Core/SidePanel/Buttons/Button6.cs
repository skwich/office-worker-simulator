using office_worker_simulator.Core.Services.SidePanel;

namespace office_worker_simulator.Core.SidePanel.Buttons;

public class Button6 : Button
{
    public override int Price => 7500;

    public Button6(CoinService coinService) : base(coinService)
    {
    }

    public override void BuyWorker()
    {
        base.BuyWorker();
    }
}