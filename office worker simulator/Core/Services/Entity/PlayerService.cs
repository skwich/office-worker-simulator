using Microsoft.Xna.Framework;
using office_worker_simulator.Core.Entity;

namespace office_worker_simulator.Core.Services.Entity;

public class PlayerService
{
    public readonly Player Player;

    public PlayerService(Player player) => Player = player;

    public void Move(Vector2 position) => Player.Move(position);
}