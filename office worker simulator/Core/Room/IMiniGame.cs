namespace office_worker_simulator.Core.Room;

public interface IMiniGame
{
	public string Title { get; }
	public string Text { get; }
	public int Answer { get; }
	public object PlayerInput { get; }
	public bool IsPlayerFinishedEnteringData { get; set; }
	public void Start();
	public void Input();
}