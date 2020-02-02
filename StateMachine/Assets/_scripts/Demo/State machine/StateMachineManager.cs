using System;
using UnityEngine;

public class StateMachineManager : StateMachine
{
	public static event Action OnPause = delegate { };
	public static event Action OnResume = delegate { };

	public static event Action<State> OnStateChange = delegate { };

	private State _upState;
	private State _downState;

	private void Awake() {
		Init();
	}

	private void Init() {
		OnPause += OnPauseEvent;
		OnResume += OnResumeEvent;

		_upState = new StateUp().InitializeState();

		_downState = new StateDown().InitializeState();

		ChangeState(_upState);
	}

	override protected void Update() {
		base.Update();

		UpdateInput();
	}

	private void UpdateInput() {
		if(Input.GetKeyDown(KeyCode.P)) {
			HandlePause();
		} else if(Input.GetKeyDown(KeyCode.R)) {
			HandleResume();
		}

		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			ChangeState(_upState);
		} else if(Input.GetKeyDown(KeyCode.DownArrow)) {
			ChangeState(_downState);
		}
	}

	public override bool ChangeState(State newState) {
		bool stateChanged = base.ChangeState(newState);
		if (stateChanged) {
			OnStateChange(newState);
		}

		return stateChanged;
	}

	private void HandlePause() {
		if (isPaused) return;
		Pause();
		OnPause();
	}

	private void HandleResume() {
		if (!isPaused) return;
		Resume();
		OnResume();
	}

	private void OnPauseEvent() {
		Debug.Log("OnPause event fired");
	}

	private void OnResumeEvent() {
		Debug.Log("OnResume event fired");
	}
}