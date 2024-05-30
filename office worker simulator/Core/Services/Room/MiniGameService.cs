using office_worker_simulator.Core.Room;

namespace office_worker_simulator.Core.Services.Room;

public class MiniGameService
{
	public IMiniGame MiniGame;

	public string Title => MiniGame.Title;
	public string Text => MiniGame.Text;
	public int Answer => MiniGame.Answer;
	public object PlayerInput => MiniGame.PlayerInput;
	public bool IsPlayerFinishedEnteringData => MiniGame.IsPlayerFinishedEnteringData;
	public void Start() => MiniGame.Start();
	public void Input() => MiniGame.Input();
}