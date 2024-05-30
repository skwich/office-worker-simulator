using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using office_worker_simulator.Core.Entity;
using office_worker_simulator.Core.Services.Entity;
using office_worker_simulator.Core.Services.Room;

namespace office_worker_simulator.Components.Entity;

public class PlayerComponent : DrawableGameComponent
{
    private SpriteBatch spriteBatch;
    private Texture2D playerTexture;
    
    private AnimatedSprite playerIdleAnim;
    private Texture2D[] idleTextures;
    
    private AnimatedSprite playerRunDownAnim;
    private AnimatedSprite playerRunLeftAnim;
    private AnimatedSprite playerRunUpAnim;
    private AnimatedSprite playerRunRightAnim;
    
    private Texture2D[] runDownTextures;
    private Texture2D[] runLeftTextures;
    private Texture2D[] runUpTextures;
    private Texture2D[] runRightTextures;

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
        
        runDownTextures = new[]
        {
            Game.Content.Load<Texture2D>("Entity/Player/run_down1"),
            Game.Content.Load<Texture2D>("Entity/Player/run_down2"),
            Game.Content.Load<Texture2D>("Entity/Player/run_down3")
        };
        
        runLeftTextures = new[]
        {
            Game.Content.Load<Texture2D>("Entity/Player/run_left1"),
            Game.Content.Load<Texture2D>("Entity/Player/run_left2"),
            Game.Content.Load<Texture2D>("Entity/Player/run_left3")
        };
        
        runUpTextures = new[]
        {
            Game.Content.Load<Texture2D>("Entity/Player/run_up1"),
            Game.Content.Load<Texture2D>("Entity/Player/run_up2"),
            Game.Content.Load<Texture2D>("Entity/Player/run_up3")
        };
        
        runRightTextures = new[]
        {
            Game.Content.Load<Texture2D>("Entity/Player/run_right1"),
            Game.Content.Load<Texture2D>("Entity/Player/run_right2"),
            Game.Content.Load<Texture2D>("Entity/Player/run_right3")
        };
        
        playerIdleAnim = new AnimatedSprite(idleTextures);
        playerRunDownAnim = new AnimatedSprite(runDownTextures);
        playerRunLeftAnim = new AnimatedSprite(runLeftTextures);
        playerRunUpAnim = new AnimatedSprite(runUpTextures);
        playerRunRightAnim = new AnimatedSprite(runRightTextures);
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
        {
            playerService.Move(new Vector2(player.Position.X - walkSpeed, player.Position.Y));
            playerTexture = playerRunLeftAnim.GetTexture(gameTime, 200);
        }
        else if (state.IsKeyDown(Keys.Right))
        {
            playerService.Move(new Vector2(player.Position.X + walkSpeed, player.Position.Y));
            playerTexture = playerRunRightAnim.GetTexture(gameTime, 200);
        }
        else if (state.IsKeyDown(Keys.Up))
        {
            playerService.Move(new Vector2(player.Position.X, player.Position.Y - walkSpeed));
            playerTexture = playerRunUpAnim.GetTexture(gameTime, 200);
        }
        else if (state.IsKeyDown(Keys.Down))
        {
            playerService.Move(new Vector2(player.Position.X, player.Position.Y + walkSpeed));
            playerTexture = playerRunDownAnim.GetTexture(gameTime, 200);
        }
        else
            playerTexture = playerIdleAnim.GetTexture(gameTime, 1500);
    }
}