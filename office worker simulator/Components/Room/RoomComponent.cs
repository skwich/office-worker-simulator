using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace office_worker_simulator.Components.Room;

public class RoomComponent : DrawableGameComponent
{
    private SpriteBatch spriteBatch;
    private Texture2D roomTexture;

    public RoomComponent(Game game) : base(game)
    {
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        roomTexture = Game.Content.Load<Texture2D>("MainGame/Room");
    }

    public override void Draw(GameTime gameTime)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(
            roomTexture,
            new Vector2(503, 0),
            null,
            Color.White
        );
        spriteBatch.End();
    }
}