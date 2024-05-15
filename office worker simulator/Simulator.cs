using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
//using office_worker_simulator.Components.Room;
using office_worker_simulator.Components.SidePanel;
using office_worker_simulator.Core.Services.SidePanel;
using office_worker_simulator.Core.SidePanel.Items;
using office_worker_simulator.Initialization;

namespace office_worker_simulator;

public class Simulator : Game
{
    private readonly GraphicsDeviceManager graphics;

    public Simulator()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        // Components
        Components.Add(new SidePanelComponent(this));
        Components.Add(new ButtonComponent(this));
        Components.Add(new CoinComponent(this));
        //Components.Add(new RoomComponent(this));

        // Services
        Services.AddService(new ButtonService());
        Services.AddService(new Coin());
        Services.AddService(new CoinService(Services.GetService<Coin>()));
    }

    protected override void Initialize()
    {
        graphics.InitializeDisplayMode().ApplyChanges();
        base.Initialize();
    }

    protected override void LoadContent()
    {
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.FromNonPremultiplied(220, 220, 220, 255));
        base.Draw(gameTime);
    }
}