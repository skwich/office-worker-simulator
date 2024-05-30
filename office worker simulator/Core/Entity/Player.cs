using System.Linq;
using Microsoft.Xna.Framework;

namespace office_worker_simulator.Core.Entity;

public class Player
{
	public Vector2 Position { get; private set; } = new(700, 400);

	private readonly Vector4[] restrictedAreas =
	{
		new(0, 0, 519, 720), // sidePanel or roomLeftSide
		new(0, 0, 1280, 172), // roomTopSide
		new(519, 610, 1280, 720), // roomBottomSide
		new(1200, 172, 1280, 720), // roomRightSide
		new(519, 227, 552, 446), // sofa1
		new(552, 264, 614, 446), // sofa2
		new(519, 576, 605, 720), // pc
		new(726, 548, 966, 720), // chairs
		new(966, 576, 1051, 720), // pcGreen
		new(1136, 485, 1280, 720), // flowerAtCorner
		new(977, 189, 1185, 364), // table
		new(1064, 0, 1197, 275), // chairAtCorner
		new(725, 172, 918, 215), // flowerAndGlobe
	};

	public void Move(Vector2 position)
	{
		if (IsRestrictedArea(position))
		{
			var delta = position - Position;
		
			if (delta.X != 0 && delta.Y != 0)
			{
				var newPos = position;
				var lastPos = newPos;
		
				while (IsRestrictedArea(newPos))
				{
					newPos = !IsRestrictedArea(new Vector2(Position.X + delta.X, Position.Y)) ? 
						new Vector2(Position.X + delta.X, Position.Y) :
						new Vector2(Position.X, Position.Y + delta.Y);
				
					delta = lastPos - newPos;
					lastPos = newPos;
				}
		
				Position = newPos;
			}
			
			return;
		}

		Position = position;
	}

	private bool IsRestrictedArea(Vector2 position)
	{
		return restrictedAreas.Any(area => position.X >= area.X && position.Y >= area.Y && position.X <= area.Z && position.Y <= area.W);
	}
}