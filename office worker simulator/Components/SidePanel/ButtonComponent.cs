using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using office_worker_simulator.Core.Services.SidePanel;
using office_worker_simulator.Core.SidePanel.Buttons;

namespace office_worker_simulator.Components.SidePanel;

public class ButtonComponent : DrawableGameComponent
{
    private SpriteBatch spriteBatch;
    private Texture2D button1Texture;
    private Texture2D button2Texture;
    private Texture2D button3Texture;
    private Texture2D button4Texture;
    private Texture2D button5Texture;
    private Texture2D button6Texture;

    private MouseState previousMouseState;
    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;
    private Button button5;
    private Button button6;

    public ButtonComponent(Game game) : base(game)
    {
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        button1Texture = Game.Content.Load<Texture2D>("SidePanel/button 1");
        button2Texture = Game.Content.Load<Texture2D>("SidePanel/button 2");
        button3Texture = Game.Content.Load<Texture2D>("SidePanel/button 3");
        button4Texture = Game.Content.Load<Texture2D>("SidePanel/button 4");
        button5Texture = Game.Content.Load<Texture2D>("SidePanel/button 5");
        button6Texture = Game.Content.Load<Texture2D>("SidePanel/button 6");

        button1 = new Button(Game.Services.GetService<CoinService>(), 30, 1);
        button2 = new Button(Game.Services.GetService<CoinService>(), 65, 5);
        button3 = new Button(Game.Services.GetService<CoinService>(), 175, 20);
        button4 = new Button(Game.Services.GetService<CoinService>(), 300, 50);
        button5 = new Button(Game.Services.GetService<CoinService>(), 500, 150);
        button6 = new Button(Game.Services.GetService<CoinService>(), 7500, 1);
    }

    public override void Update(GameTime gameTime)
    {
        var mouseState = Mouse.GetState();
        if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
        {
            var buttonService = Game.Services.GetService<ButtonService>();
            var clickLocation = mouseState.Position;

            if (clickLocation.X is >= 40 and <= 476)
            {
                switch (clickLocation.Y)
                {
                    case >= 113 and <= 188:
                        buttonService.BuyWorker(button1);
                        break;
                    case >= 208 and <= 284:
                        buttonService.BuyWorker(button2);
                        break;
                    case >= 304 and <= 378:
                        buttonService.BuyWorker(button3);
                        break;
                    case >= 400 and <= 472:
                        buttonService.BuyWorker(button4);
                        break;
                    case >= 492 and <= 568:
                        buttonService.BuyWorker(button5);
                        break;
                    case >= 590 and <= 662:
                        buttonService.BuyWorker(button6);
                        break;
                }
            }
        }

        previousMouseState = mouseState;
    }

    public override void Draw(GameTime gameTime)
    {
        var coinService = Game.Services.GetService<CoinService>();
        var coinCount = coinService.Coin.CoinCounter;

        spriteBatch.Begin();
        spriteBatch.Draw(
            button1Texture,
            new Vector2(40, 113),
            null,
            coinCount >= button1.Price ? Color.White : Color.FromNonPremultiplied(220, 220, 220, 255),
            0f,
            Vector2.Zero,
            1f,
            SpriteEffects.None,
            0f
        );
        spriteBatch.Draw(
            button2Texture,
            new Vector2(40, 208),
            null,
            coinCount >= button2.Price ? Color.White : Color.FromNonPremultiplied(220, 220, 220, 255),
            0f,
            Vector2.Zero,
            1f,
            SpriteEffects.None,
            0f
        );
        spriteBatch.Draw(
            button3Texture,
            new Vector2(40, 303),
            null,
            coinCount >= button3.Price ? Color.White : Color.FromNonPremultiplied(220, 220, 220, 255),
            0f,
            Vector2.Zero,
            1f,
            SpriteEffects.None,
            0f
        );
        spriteBatch.Draw(
            button4Texture,
            new Vector2(40, 398),
            null,
            coinCount >= button4.Price ? Color.White : Color.FromNonPremultiplied(220, 220, 220, 255),
            0f,
            Vector2.Zero,
            1f,
            SpriteEffects.None,
            0f
        );
        spriteBatch.Draw(
            button5Texture,
            new Vector2(40, 493),
            null,
            coinCount >= button5.Price ? Color.White : Color.FromNonPremultiplied(220, 220, 220, 255),
            0f,
            Vector2.Zero,
            1f,
            SpriteEffects.None,
            0f
        );
        spriteBatch.Draw(
            button6Texture,
            new Vector2(40, 588),
            null,
            coinCount >= button6.Price ? Color.White : Color.FromNonPremultiplied(220, 220, 220, 255),
            0f,
            Vector2.Zero,
            1f,
            SpriteEffects.None,
            0f
        );
        spriteBatch.End();
    }
}