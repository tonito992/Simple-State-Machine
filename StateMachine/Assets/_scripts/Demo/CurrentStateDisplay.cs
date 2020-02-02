using System;
using TMPro;
using UnityEngine;

public class CurrentStateDisplay : MonoBehaviour
{
	[SerializeField] private TMP_Text _currentStateText;
	private string _currentStateName;

	private void Awake() {
		Init();
	}

	private void Init() {
		StateMachineManager.OnStateChange += OnStateChanged;
		StateMachineManager.OnPause += OnPause;
		StateMachineManager.OnResume += OnResume;
	}

	private void OnStateChanged(State newState) {
		_currentStateName = newState.GetType().Name;
		_currentStateText.SetText(_currentStateName);
	}

	private void OnPause() {
		_currentStateText.SetText("State machine is paused, press R to resume");
	}

	private void OnResume() {
		_currentStateText.SetText("Resumed: " + _currentStateName);
	}
}