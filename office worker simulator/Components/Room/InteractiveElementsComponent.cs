using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace office_worker_simulator.Components.Room;

public class InteractiveElementsComponent : DrawableGameComponent
{
    private SpriteBatch spriteBatch;
    private Texture2D switcherTexture;
    private Texture2D pcTexture;
    private Texture2D pcGreenTexture;
    private Texture2D globeTexture;
    private Texture2D cakeTexture;
    private Texture2D glowedSwitcherTexture;
    private Texture2D glowedPCTexture;
    private Texture2D glowedPCGreenTexture;
    private Texture2D glowedGlobeTexture;
    private Texture2D glowedCakeTexture;
    
    private bool isSwitcherNear;
    private bool isPCNear;
    private bool isPCGreenNear;
    private bool isGlobeNear;
    private bool isCakeNear;

    public InteractiveElementsComponent(Game game) : base(game)
    {
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        switcherTexture = Game.Content.Load<Texture2D>("MainGame/InteractiveElements/switcher");
        pcTexture = Game.Content.Load<Texture2D>("MainGame/InteractiveElements/pc");
        pcGreenTexture = Game.Content.Load<Texture2D>("MainGame/InteractiveElements/pcGreen");
        globeTexture = Game.Content.Load<Texture2D>("MainGame/InteractiveElements/globe");
        cakeTexture = Game.Content.Load<Texture2D>("MainGame/InteractiveElements/cake");
        glowedSwitcherTexture = Game.Content.Load<Texture2D>("MainGame/InteractiveElements/glowedSwitcher");
        glowedPCTexture = Game.Content.Load<Texture2D>("MainGame/InteractiveElements/glowedPC");
        glowedPCGreenTexture = Game.Content.Load<Texture2D>("MainGame/InteractiveElements/glowedPCGreen");
        glowedGlobeTexture = Game.Content.Load<Texture2D>("MainGame/InteractiveElements/glowedGlobe");
        glowedCakeTexture = Game.Content.Load<Texture2D>("MainGame/InteractiveElements/glowedCake");
    }

    public override void Draw(GameTime gameTime)
    {
        spriteBatch.Begin();

        spriteBatch.Draw(
            isSwitcherNear ? glowedSwitcherTexture : switcherTexture,
            isSwitcherNear ? new Vector2(539,110) : new Vector2(542, 113),
            null,
            Color.White
        );

        spriteBatch.Draw(
            isPCNear ? glowedPCTexture : pcTexture,
            isPCNear ? new Vector2(524,601) : new Vector2(527, 604),
            null,
            Color.White
        );

        spriteBatch.Draw(
            isPCGreenNear ? glowedPCGreenTexture : pcGreenTexture,
            isPCGreenNear ? new Vector2(966,601) : new Vector2(969, 604),
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

    public override void Update(GameTime gameTime)
    {
        // TODO: РЕАЛИЗОВАТЬ ПОДСВЕТКУ ПРЕДМЕТА, КОГДА ИГРОК ПОДХОДИТ К НЕМУ, ПРИ УСЛОВИИ, ЧТО У ПРЕДМЕТА ЕСТЬ ИНТЕРАКТИВ
    }
}