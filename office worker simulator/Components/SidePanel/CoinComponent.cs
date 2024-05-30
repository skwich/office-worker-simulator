using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using office_worker_simulator.Core.Services;
using office_worker_simulator.Core.Services.SidePanel;
using office_worker_simulator.Core.SidePanel.Items;

namespace office_worker_simulator.Components.SidePanel;

public class CoinComponent : DrawableGameComponent
{
    private SpriteBatch spriteBatch;
    private SpriteFont coinCounterSpriteFont;
    private SpriteFont passiveIncomeSpriteFont;

    private Vector2 counterPosition = new(410, 26);
    private double lastUpdateTime;

    public CoinComponent(Game game) : base(game)
    {
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        coinCounterSpriteFont = Game.Content.Load<SpriteFont>("SidePanel/CoinCounter");
        passiveIncomeSpriteFont = Game.Content.Load<SpriteFont>("SidePanel/PassiveIncome");
    }

    public override void Draw(GameTime gameTime)
    {
        var coin = Game.Services.GetService<Coin>();

        spriteBatch.Begin();
        spriteBatch.DrawString(
            coinCounterSpriteFont,
            $"{coin.CoinCounter}",
            counterPosition,
            Color.Black
        );
        spriteBatch.DrawString(
            passiveIncomeSpriteFont,
            $"Ваш пассивный доход:{coin.ExtraCoins}$",
            new Vector2(122, 670),
            Color.FromNonPremultiplied(239, 210, 166, 255)
        );
        spriteBatch.End();
    }

    public override void Update(GameTime gameTime)
    {
        var coinService = Game.Services.GetService<CoinService>();
        var coin = coinService.Coin;
        var state = Keyboard.GetState();

        // DEBUG
        if (state.IsKeyDown(Keys.F1))
            coinService.AddCoins(1);

        // Пассивный доход каждую секунду
        if (gameTime.TotalGameTime.TotalSeconds - lastUpdateTime >= 1)
        {
            coinService.AddCoins(coin.ExtraCoins);
            lastUpdateTime = gameTime.TotalGameTime.TotalSeconds;
        }

        counterPosition = coinService.Coin.CoinCounter switch
        {
            // сдвигать позицию по X на -40, чтобы число передвигалось при переполнении
            >= 10 and < 100 => new Vector2(370, 26),
            >= 100 and < 1000 => new Vector2(330, 26),
            >= 1000 and < 10000 => new Vector2(290, 26),
            >= 10000 => new Vector2(250, 26),
            _ => new Vector2(410, 26)
        };
    }
}