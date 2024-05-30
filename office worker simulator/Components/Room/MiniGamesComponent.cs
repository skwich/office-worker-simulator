using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using office_worker_simulator.Core.Room;
using office_worker_simulator.Core.Services.SidePanel;

namespace office_worker_simulator.Components.Room;

public class MiniGamesComponent : DrawableGameComponent
{
	private bool isGameStarted;
	private bool gameFlag;
	private IMiniGame currentMiniGame;

	private SpriteBatch spriteBatch;
	private Texture2D exclamationMark;
	private int markPosition;
	private readonly Vector2[] exclamationMarkPositions =
	{
		new Vector2(530, 59), // switcher
		new Vector2(903, 151), // globe
		new Vector2(1147, 315), // cake
		new Vector2(543, 553), // pc
		new Vector2(981, 554), // pc green
	};

	private Texture2D mgBackground;
	private Texture2D mgField;
	private SpriteFont spriteFont;

	public MiniGamesComponent(Game game) : base(game)
	{
	}

	protected override void LoadContent()
	{
		spriteBatch = new SpriteBatch(GraphicsDevice);
		spriteFont = Game.Content.Load<SpriteFont>("MiniGames/text");
		exclamationMark = Game.Content.Load<Texture2D>("MainGame/InteractiveElements/exclamationMark");
		mgBackground = Game.Content.Load<Texture2D>("MiniGames/minigames background");
		mgField = Game.Content.Load<Texture2D>("MiniGames/minigame field");
	}

	public override void Draw(GameTime gameTime)
	{
		spriteBatch.Begin();

		if (isExclamationMarkExist)
			spriteBatch.Draw(
				exclamationMark,
				exclamationMarkPositions[markPosition],
				Color.White
			);

		if (isGameStarted)
		{
			spriteBatch.Draw(
				mgBackground,
				new Vector2(0,0),
				Color.White
			);
			
			spriteBatch.Draw(
				mgField,
				new Vector2(337,140),
				Color.White
			);
			
			spriteBatch.DrawString(
				spriteFont,
				$"{currentMiniGame.Title}",
				new Vector2(510, 175),
				Color.White
			);
			
			spriteBatch.DrawString(
				spriteFont,
				$"{currentMiniGame.Text}",
				new Vector2(510, 320),
				Color.White
			);
			
			spriteBatch.DrawString(
				spriteFont,
				$"Ответ : {currentMiniGame.PlayerInput}",
				new Vector2(510, 412),
				Color.White
			);
		}

		spriteBatch.End();
	}

	private double lastTime;
	private bool isExclamationMarkExist;

	public override void Update(GameTime gameTime)
	{
		var interactiveItems = Game.Services.GetService<InteractiveItems>();
		var coinService = Game.Services.GetService<CoinService>();
		var random = new Random();

		if (gameTime.TotalGameTime.TotalSeconds - lastTime >= 6 && !isExclamationMarkExist && !isGameStarted)
		{
			markPosition = random.Next(0, 5);
			isExclamationMarkExist = true;

			lastTime = gameTime.TotalGameTime.TotalSeconds;
		}

		if (Keyboard.GetState().IsKeyDown(Keys.Space) &&
			isExclamationMarkExist &&
			(
				(interactiveItems.IsSwitcherNear && markPosition == 0) ||
				(interactiveItems.IsGlobeNear && markPosition == 1) ||
				(interactiveItems.IsCakeNear && markPosition == 2) ||
				(interactiveItems.IsPCNear && markPosition == 3) ||
				(interactiveItems.IsPCGreenNear && markPosition == 4)
			)
		)
		{
			isGameStarted = true;
			gameFlag = true;
		}

		if (isGameStarted)
		{
			isExclamationMarkExist = false;

			if (gameFlag)
			{
				switch (random.Next(0, 1))
				{
					case 0:
						currentMiniGame = new MiniGameMath();
						break;
				}
				
				currentMiniGame.Start();
				gameFlag = false;
			}

			if (!currentMiniGame.IsPlayerFinishedEnteringData && Keyboard.GetState().IsKeyDown(Keys.Enter))
				currentMiniGame.IsPlayerFinishedEnteringData = true;
				

			if (gameTime.TotalGameTime.TotalSeconds - lastTime >= 0.1)
			{
				if (!currentMiniGame.IsPlayerFinishedEnteringData)
					currentMiniGame.Input();
				else
				{
					if (currentMiniGame.Answer.ToString() == currentMiniGame.PlayerInput.ToString())
						coinService.AddCoins(5 * (1 + (int)gameTime.TotalGameTime.TotalMinutes));
					else
						Console.WriteLine("FAILURE MESSAGE");
				
					isGameStarted = false;
				}

				lastTime = gameTime.TotalGameTime.TotalSeconds;
			}
		}
	}
}