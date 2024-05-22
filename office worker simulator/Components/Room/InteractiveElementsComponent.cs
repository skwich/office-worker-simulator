using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using office_worker_simulator.Core.Entity;

namespace office_worker_simulator.Components.Room;

public class InteractiveElementsComponent : DrawableGameComponent
{
	private SpriteBatch spriteBatch;
	private Texture2D pcTexture;
	private Texture2D pcGreenTexture;
	private Texture2D glowedPCTexture;
	private Texture2D glowedPCGreenTexture;

	private bool isPCNear;
	private bool isPCGreenNear;

	public InteractiveElementsComponent(Game game) : base(game)
	{
	}

	protected override void LoadContent()
	{
		spriteBatch = new SpriteBatch(GraphicsDevice);

		pcTexture = Game.Content.Load<Texture2D>("MainGame/InteractiveElements/pc");
		pcGreenTexture = Game.Content.Load<Texture2D>("MainGame/InteractiveElements/pcGreen");
		glowedPCTexture = Game.Content.Load<Texture2D>("MainGame/InteractiveElements/glowedPC");
		glowedPCGreenTexture = Game.Content.Load<Texture2D>("MainGame/InteractiveElements/glowedPCGreen");
	}

	public override void Draw(GameTime gameTime)
	{
		spriteBatch.Begin();

		spriteBatch.Draw(
			isPCNear ? glowedPCTexture : pcTexture,
			isPCNear ? new Vector2(524, 601) : new Vector2(527, 604),
			null,
			Color.White
		);

		spriteBatch.Draw(
			isPCGreenNear ? glowedPCGreenTexture : pcGreenTexture,
			isPCGreenNear ? new Vector2(966, 601) : new Vector2(969, 604),
			null,
			Color.White
		);

		spriteBatch.End();
	}

	public override void Update(GameTime gameTime)
	{
		var player = Game.Services.GetService<Player>();

		isPCNear = player.Position.X is >= 510 and <= 650 && player.Position.Y is >= 490 and <= 611;
		isPCGreenNear = player.Position.X is >= 889 and <= 1098 && player.Position.Y is >= 542 and <= 610;
	}
}