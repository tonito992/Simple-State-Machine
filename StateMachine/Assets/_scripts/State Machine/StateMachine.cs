using UnityEngine;

public class StateMachine : MonoBehaviour
{
	protected bool isPaused { get; set; }

	private State _currentState;

	virtual protected void Update() {
		Tick();
	}

	virtual public bool ChangeState(State newState) {
		if(isPaused) return false;
		if(_currentState == newState) {
			Debug.LogWarning("Cannot change to same state");
			return false;
		} else {
			if (_currentState != null) {
				_currentState.onStateExit();
			}
			_currentState = newState.onStateEnter();
		}

		return true;
	}

	protected void Pause() {
		isPaused = true;
	}

	protected void Resume() {
		isPaused = false;
	}

	private void Tick() {
		if (isPaused) return;
		_currentState.UpdateState();
	}
}