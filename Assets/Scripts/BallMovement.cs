using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour
{
    public float standardSpeed = 30f;
    public float increasedSpeed = 30f;
    [Space]
    public float drag = 1.5f;
    
    private Rigidbody _rigidbody;
    private Vector3 _velocity;

    private void Awake() => InitializeComponents();
    private void InitializeComponents()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.drag = drag;
    }

    private void Update()
    {
        var playerInput = Vector2.zero;
        playerInput.x = Input.GetAxisRaw("Horizontal");
        playerInput.y = Input.GetAxisRaw("Vertical");
        playerInput = playerInput.normalized;

        var speed = Input.GetKey(KeyCode.LeftShift) ? increasedSpeed : standardSpeed;
        _velocity = new Vector3(playerInput.x, 0f, playerInput.y) * speed * Time.deltaTime;
    }
    
    private void FixedUpdate()
    {
        _rigidbody.AddForce(_velocity, ForceMode.VelocityChange);
    }
}
