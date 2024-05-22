using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using office_worker_simulator.Core.Entity;
using office_worker_simulator.Core.Services.Entity;

namespace office_worker_simulator.Components.Entity;

public class PlayerComponent : DrawableGameComponent
{
    private SpriteBatch spriteBatch;
    private Texture2D playerTexture;
    private AnimatedSprite playerIdleAnim;
    private AnimatedSprite playerRunAnim;
    private Texture2D[] idleTextures;
    private Texture2D[] runTextures;

    public PlayerComponent(Game game) : base(game)
    {
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        
        idleTextures = new []
        {
            Game.Content.Load<Texture2D>("Entity/Player/idle1"),
            Game.Content.Load<Texture2D>("Entity/Player/idle1"),
            Game.Content.Load<Texture2D>("Entity/Player/idle2"),
            Game.Content.Load<Texture2D>("Entity/Player/idle1"),
            Game.Content.Load<Texture2D>("Entity/Player/idle1"),
            Game.Content.Load<Texture2D>("Entity/Player/idle3"),
            Game.Content.Load<Texture2D>("Entity/Player/idle1"),
            Game.Content.Load<Texture2D>("Entity/Player/idle1")
        };

        // TODO: РЕАЛИЗОВАТЬ АНИМАЦИЮ ХОДЬБЫ
        // runTextures = new[]
        // {
        //     
        // };
        
        playerIdleAnim = new AnimatedSprite(idleTextures);
        // playerRunAnim = new AnimatedSprite(runTextures);
        playerTexture = idleTextures[0];
    }

    public override void Draw(GameTime gameTime)
    {
        var player = Game.Services.GetService<Player>();
        
        spriteBatch.Begin();
        spriteBatch.Draw(playerTexture, player.Position, null, Color.White);
        spriteBatch.End();
    }
    
    public override void Update(GameTime gameTime)
    {
        var playerService = Game.Services.GetService<PlayerService>();
        var player = playerService.Player;
        var state = Keyboard.GetState();
        var walkSpeed = 4f;
        
        if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.Up))
            playerService.Move(new Vector2(player.Position.X - walkSpeed, player.Position.Y - walkSpeed));
        else if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.Up))
            playerService.Move(new Vector2(player.Position.X + walkSpeed, player.Position.Y - walkSpeed));
        else if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.Down))
            playerService.Move(new Vector2(player.Position.X - walkSpeed, player.Position.Y + walkSpeed));
        else if (state.IsKeyDown(Keys.Right) && state.IsKeyDown(Keys.Down))
            playerService.Move(new Vector2(player.Position.X + walkSpeed, player.Position.Y + walkSpeed));
        else if (state.IsKeyDown(Keys.Left))
            playerService.Move(new Vector2(player.Position.X - walkSpeed, player.Position.Y));
        else if (state.IsKeyDown(Keys.Right))
            playerService.Move(new Vector2(player.Position.X + walkSpeed, player.Position.Y));
        else if (state.IsKeyDown(Keys.Up))
            playerService.Move(new Vector2(player.Position.X, player.Position.Y - walkSpeed));
        else if (state.IsKeyDown(Keys.Down))
            playerService.Move(new Vector2(player.Position.X, player.Position.Y + walkSpeed));
        
        playerTexture = playerIdleAnim.GetTexture(gameTime, 1500);
    }
}