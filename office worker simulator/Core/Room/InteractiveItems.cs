using office_worker_simulator.Core.Entity;

namespace office_worker_simulator.Core.Room;

public class InteractiveItems
{
	public bool IsSwitcherNear;
	public bool IsGlobeNear;
	public bool IsCakeNear;
	public bool IsPCNear;
	public bool IsPCGreenNear;

	public void GlowElementIfPlayerNear(Player player)
	{
		IsSwitcherNear = player.Position.X is >= 507 and <= 623 && player.Position.Y is >= 153 and <= 224;
		IsGlobeNear = player.Position.X is >= 820 and <= 928 && player.Position.Y is >= 162 and <= 253;
		IsCakeNear = player.Position.X is >= 1057 and <= 1233 && player.Position.Y is >= 297 and <= 439;
		IsPCNear = player.Position.X is >= 510 and <= 650 && player.Position.Y is >= 490 and <= 611;
		IsPCGreenNear = player.Position.X is >= 889 and <= 1098 && player.Position.Y is >= 542 and <= 610;
	}
}