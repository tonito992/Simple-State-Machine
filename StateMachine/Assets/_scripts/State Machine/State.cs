using UnityEngine;

public abstract class State
{
	/// <summary>
	/// Runs only once
	/// </summary>
	/// <returns></returns>
	public abstract State InitializeState();

	/// <summary>
	/// State tick
	/// </summary>
	/// <returns></returns>
	public abstract State UpdateState();

	/// <summary>
	/// Runs when current state is set to this state
	/// </summary>
	/// <returns></returns>
	public abstract State onStateEnter();

	/// <summary>
	/// Runs when stops to be current state
	/// </summary>
	/// <returns></returns>
	public abstract State onStateExit();
}