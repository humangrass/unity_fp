using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController _controller;

    private Vector3 _playerVelocity;

    public float speed = 5f;
    private bool _isGrounded;
    public float jumpHeight = 0.5f;
    public float gravity = -30f;

    // Start is called before the first frame update
    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        _isGrounded = _controller.isGrounded;
    }

    // receive this inputs for our InputManager.cs and apply them to our character controller.
    public void ProcessMove(Vector2 input)
    {
        var moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        _controller.Move(speed * Time.deltaTime * transform.TransformDirection(moveDirection));
        _playerVelocity.y += gravity * Time.deltaTime;
        if (_isGrounded && _playerVelocity.y < 0)
            _playerVelocity.y = gravity;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}