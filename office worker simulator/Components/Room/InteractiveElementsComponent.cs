using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using office_worker_simulator.Core.Entity;
using office_worker_simulator.Core.Room;
using office_worker_simulator.Core.Services.Room;

namespace office_worker_simulator.Components.Room;

public class InteractiveElementsComponent : DrawableGameComponent
{
	private SpriteBatch spriteBatch;
	private Texture2D pcTexture;
	private Texture2D pcGreenTexture;
	private Texture2D glowedPCTexture;
	private Texture2D glowedPCGreenTexture;

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
		var items = Game.Services.GetService<InteractiveItems>();
		
		spriteBatch.Begin();

		spriteBatch.Draw(
			items.IsPCNear ? glowedPCTexture : pcTexture,
			items.IsPCNear ? new Vector2(524, 601) : new Vector2(527, 604),
			null,
			Color.White
		);

		spriteBatch.Draw(
			items.IsPCGreenNear ? glowedPCGreenTexture : pcGreenTexture,
			items.IsPCGreenNear ? new Vector2(966, 601) : new Vector2(969, 604),
			null,
			Color.White
		);

		spriteBatch.End();
	}

	public override void Update(GameTime gameTime)
	{
		var items = Game.Services.GetService<InteractiveItemsService>();
		var player = Game.Services.GetService<Player>();

		items.GlowElementIfPlayerNear(player);
	}
}