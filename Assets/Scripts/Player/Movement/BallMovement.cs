using RollingBall.Player.Input;
using UnityEngine;

namespace RollingBall.Player.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallMovement : MonoBehaviour
    {
        [Header("Input Settings")] 
        [SerializeField] private PlayerInputActions inputHandler;

        [Header("Movement Settings"), Space]
        [SerializeField] private float standardSpeed = 30f;
        [SerializeField] private float increasedSpeed = 30f;
        [Space]
        [SerializeField] private float drag = 1.5f;

        private Rigidbody _rigidbody;
        private Vector3 _targetHorizontalVelocity;

        private void Awake() => InitializeRigidbody();
        private void InitializeRigidbody()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.drag = drag;
        }

        private void Update() => RecalculateVelocityByInput();
        private void RecalculateVelocityByInput()
        {
            var movementInput = inputHandler.MovementValue.normalized;
            var speed = inputHandler.SprintValue ? increasedSpeed : standardSpeed;

            _targetHorizontalVelocity = new Vector3(movementInput.x, 0f, movementInput.y) * speed * Time.deltaTime;
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(_targetHorizontalVelocity, ForceMode.VelocityChange);
        }
    }
}