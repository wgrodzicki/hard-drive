using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float MaxSpeed = 30.0f;
    public float Acceleration = 0.5f;
    public float Drag = 0.2f;
    public float TurnSpeed = 0.3f;

    private InputAction _moveInput;
    private Vector3 _direction;
    private float _speed;
    private float _turnDirection;

    private void CalculateMovement()
    {
        Vector2 moveInputValue = _moveInput.ReadValue<Vector2>();

        if (moveInputValue.y != 0.0f)
        {
            _speed += Acceleration;

            if (moveInputValue.y > 0)
                _direction = Vector3.forward;
            else
                _direction = Vector3.back;
        }
        else
        {
            _speed -= Drag;
        }

        if (_speed > MaxSpeed)
            _speed = MaxSpeed;
        else if (_speed < 0)
            _speed = 0;

        if (moveInputValue.x != 0.0f)
            _turnDirection = moveInputValue.x > 0 ? 1 : -1;
        else
            _turnDirection = 0;
        
        this.transform.Translate(_speed * Time.deltaTime * _direction);
        this.transform.Rotate(new Vector3(0.0f, _turnDirection * TurnSpeed, 0.0f));
    }

    private void Start()
    {
        _moveInput = InputSystem.actions.FindAction("Move");
        _speed = 0;
    }

    private void Update()
    {
        CalculateMovement();
    }
}
