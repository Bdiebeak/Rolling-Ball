using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RollingBall.Player.Input
{
	/// <summary>
	/// This class handles input and write it to properties.
	/// </summary>
	[RequireComponent(typeof(PlayerInput))]
	public class PlayerActionsReader : PlayerInputActions
	{
		private PlayerInput _playerInput;
		private Dictionary<PlayerActions, InputAction> _inputActions;

		private void Update()
		{
			// This initialization is handled in Update because Unity Input System's documentation says do it.
			// https://docs.unity3d.com/Packages/com.unity.inputsystem@1.3/api/UnityEngine.InputSystem.PlayerInput.html
			if (_playerInput == null || _inputActions == null) Reinitialize();
			HandleInput();
		}

		private void Reinitialize()
		{
			_playerInput = GetComponent<PlayerInput>();
			_inputActions = new Dictionary<PlayerActions, InputAction>();
			
			foreach (var actionValue in (PlayerActions[])Enum.GetValues(typeof(PlayerActions)))
				_inputActions.Add(actionValue, _playerInput.actions[actionValue.ToString()]);
		}

		private void HandleInput()
		{
			MovementValue = _inputActions[PlayerActions.Movement].ReadValue<Vector2>();
			LookValue = _inputActions[PlayerActions.Look].ReadValue<Vector2>();
			SprintValue = _inputActions[PlayerActions.Sprint].inProgress;
		}
	}
}