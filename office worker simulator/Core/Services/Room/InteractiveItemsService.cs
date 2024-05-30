using office_worker_simulator.Core.Entity;
using office_worker_simulator.Core.Room;

namespace office_worker_simulator.Core.Services.Room;

public class InteractiveItemsService
{
	private readonly InteractiveItems items;

	public InteractiveItemsService(InteractiveItems items) => this.items = items;

	public void GlowElementIfPlayerNear(Player player) => items.GlowElementIfPlayerNear(player);
}