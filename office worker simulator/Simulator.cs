using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using office_worker_simulator.Components.Entity;
using office_worker_simulator.Components.Room;
using office_worker_simulator.Components.SidePanel;
using office_worker_simulator.Core.Entity;
using office_worker_simulator.Core.Room;
using office_worker_simulator.Core.Services.Entity;
using office_worker_simulator.Core.Services.Room;
using office_worker_simulator.Core.Services.SidePanel;
using office_worker_simulator.Core.SidePanel.Items;
using office_worker_simulator.Initialization;

namespace office_worker_simulator;

public class Simulator : Game
{
    private readonly GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private Texture2D messageTexture;
    private bool startMessage = true;

    public Simulator()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        // Components
        Components.Add(new RoomComponent(this));
        Components.Add(new SidePanelComponent(this));
        Components.Add(new ButtonComponent(this));
        Components.Add(new CoinComponent(this));
        Components.Add(new PlayerComponent(this));
        Components.Add(new InteractiveElementsComponent(this));
        Components.Add(new MiniGamesComponent(this));

        // Services
        Services.AddService(new ButtonService());
        Services.AddService(new InteractiveItems());
        Services.AddService(new InteractiveItemsService(Services.GetService<InteractiveItems>()));
        Services.AddService(new Coin());
        Services.AddService(new CoinService(Services.GetService<Coin>()));
        Services.AddService(new MiniGameMath());
        Services.AddService(new Player());
        Services.AddService(new PlayerService(Services.GetService<Player>()));
    }

    protected override void Initialize()
    {
        graphics.InitializeDisplayMode().ApplyChanges();
        base.Initialize();
        spriteBatch = new SpriteBatch(GraphicsDevice);
        messageTexture = Content.Load<Texture2D>("message");
    }

    protected override void LoadContent()
    {
    }

    private double lastTime;
    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        if (Keyboard.GetState().IsKeyDown(Keys.F11) && gameTime.TotalGameTime.TotalMilliseconds - lastTime >= 300)
        {
            graphics.IsFullScreen = !graphics.IsFullScreen;
            graphics.ApplyChanges();
            lastTime = gameTime.TotalGameTime.TotalMilliseconds;
        }

        if (startMessage && Keyboard.GetState().IsKeyDown(Keys.Space))
            startMessage = false;
        else
            base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.FromNonPremultiplied(220, 220, 220, 255));
        base.Draw(gameTime);
        if (startMessage)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(messageTexture, Vector2.Zero, Color.White);
            spriteBatch.End();
        }
    }
}