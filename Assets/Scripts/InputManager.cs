using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerInput.OnFootActions _onFoot;

    private PlayerMotor _motor;
    private PlayerLook _look;

    // Start is called before the first frame update
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _onFoot = _playerInput.OnFoot;

        _motor = GetComponent<PlayerMotor>();
        _look = GetComponent<PlayerLook>();

        _onFoot.Jump.performed += ctx => _motor.Jump();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // tell the playermotor to move using the value from our movement action
        _motor.ProcessMove(_onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        _look.ProcessLook(_onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _onFoot.Enable();
    }

    private void OnDisable()
    {
        _onFoot.Disable();
    }
}