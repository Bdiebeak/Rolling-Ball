using RollingBall.Helpers;
using UnityEngine;

namespace RollingBall.Player.Input
{
	/// <summary>
	/// This is an abstract class which you can use to have PlayerInput values.
	/// </summary>
	public abstract class PlayerInputHandler : MonoBehaviourSingleton<PlayerInputHandler>
	{
		public Vector2 MovementValue { get; protected set; }
		public Vector2 LookValue { get; protected set; }
		public bool SprintValue { get; protected set; }
	}
}