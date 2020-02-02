using UnityEngine;

public class StateUp : State
{
	public override State InitializeState() {
		return this;
	}

	public override State onStateEnter() {
		Debug.Log("onStateEnter: " + GetType().Name);

		return this;
	}

	public override State onStateExit() {
		Debug.Log("onStateExit: " + GetType().Name);

		return this;
	}

	public override State UpdateState() {
		return this;
	}
}