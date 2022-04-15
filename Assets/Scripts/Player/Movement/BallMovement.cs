using RollingBall.Player.Input;
using UnityEngine;

namespace RollingBall.Player.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallMovement : MonoBehaviour
    {
        [Header("Input Settings")] 
        [SerializeField] private PlayerInputHandler inputHandler;

        [Header("Movement Settings"), Space]
        [SerializeField] private float standardSpeed = 30f;
        [SerializeField] private float increasedSpeed = 30f;
        [Space]
        [SerializeField] private float drag = 1.5f;
        [Space]
        [SerializeField] private bool shouldMoveRelativeToCamera = true;

        private Transform _cameraTransform;
        private Rigidbody _rigidbody;
        private Vector3 _targetHorizontalVelocity;

        private void Awake()
        {
            InitializeCamera();
            InitializeRigidbody();
        }

        private void InitializeCamera()
        {
            _cameraTransform = UnityEngine.Camera.main.transform;
        }
        
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

            var horizontalMovement = new Vector3(movementInput.x, 0f, movementInput.y);
            if (shouldMoveRelativeToCamera)
            {
                horizontalMovement = _cameraTransform.TransformVector(horizontalMovement).normalized;
                horizontalMovement.y = 0f;
            }

            _targetHorizontalVelocity = horizontalMovement * speed * Time.deltaTime;
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(_targetHorizontalVelocity, ForceMode.VelocityChange);
        }
    }
}