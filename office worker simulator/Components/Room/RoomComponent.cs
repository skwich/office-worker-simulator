using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace office_worker_simulator.Components.Room;

public class RoomComponent : DrawableGameComponent
{
    private SpriteBatch spriteBatch;
    private Texture2D roomTexture;
    
    private Texture2D switcherTexture;
    private Texture2D globeTexture;
    private Texture2D cakeTexture;
    private Texture2D glowedSwitcherTexture;
    private Texture2D glowedGlobeTexture;
    private Texture2D glowedCakeTexture;
    
    private bool isSwitcherNear;
    private bool isGlobeNear;
    private bool isCakeNear;

    public RoomComponent(Game game) : base(game)
    {
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        roomTexture = Game.Content.Load<Texture2D>("MainGame/Room");
        
        switcherTexture = Game.Content.Load<Texture2D>("MainGame/InteractiveElements/switcher");
        globeTexture = Game.Content.Load<Texture2D>("MainGame/InteractiveElements/globe");
        cakeTexture = Game.Content.Load<Texture2D>("MainGame/InteractiveElements/cake");
        glowedSwitcherTexture = Game.Content.Load<Texture2D>("MainGame/InteractiveElements/glowedSwitcher");
        glowedGlobeTexture = Game.Content.Load<Texture2D>("MainGame/InteractiveElements/glowedGlobe");
        glowedCakeTexture = Game.Content.Load<Texture2D>("MainGame/InteractiveElements/glowedCake");
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
        
        spriteBatch.Draw(
            isSwitcherNear ? glowedSwitcherTexture : switcherTexture,
            isSwitcherNear ? new Vector2(539,110) : new Vector2(542, 113),
            null,
            Color.White
        );

        spriteBatch.Draw(
            isGlobeNear ? glowedGlobeTexture : globeTexture,
            isGlobeNear ? new Vector2(860,195) : new Vector2(863, 198),
            null,
            Color.White
        );

        spriteBatch.Draw(
            isCakeNear ? glowedCakeTexture : cakeTexture,
            isCakeNear ? new Vector2(1130,364) : new Vector2(1133, 367),
            null,
            Color.White
        );
        
        spriteBatch.End();
    }
}