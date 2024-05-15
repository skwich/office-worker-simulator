using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace office_worker_simulator.Components.SidePanel;

public class SidePanelComponent : DrawableGameComponent
{
    private SpriteBatch spriteBatch;
    private Texture2D flatUIBackGroundTexture;
    private Texture2D textMenuAndCoinTexture;
    
    
    public SidePanelComponent(Game game) : base(game)
    {
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        flatUIBackGroundTexture = Game.Content.Load<Texture2D>("flat ui interface");
        textMenuAndCoinTexture = Game.Content.Load<Texture2D>("text menu and coin");
    }
    
    public override void Draw(GameTime gameTime)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(
            flatUIBackGroundTexture,
            Vector2.Zero, 
            null,
            Color.White
        );
        spriteBatch.Draw(
            textMenuAndCoinTexture,
            new Vector2(58, 27), 
            null,
            Color.White
        );
        spriteBatch.End();
    }
}