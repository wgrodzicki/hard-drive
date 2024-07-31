using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float MaxSpeed = 30.0f;
    public float Acceleration = 0.5f;
    public float Drag = 0.2f;
    public float TurnSpeed = 0.3f;

    [HideInInspector]
    public bool IsGrounded { get; private set; } = true;

    [SerializeField]
    private List<WheelController> _wheelControllers = new List<WheelController>();

    private InputAction _moveInput;
    private Vector2 _moveInputValue;
    private Vector3 _direction;
    private float _speed;
    private float _turnDirection;

    private void CalculateMovement()
    {
        if (IsGrounded)
            _moveInputValue = _moveInput.ReadValue<Vector2>();

        if (_moveInputValue.y != 0.0f)
        {
            _speed += Acceleration;

            if (_moveInputValue.y >= 0)
                _direction = Vector3.forward;
            else
                _direction = Vector3.back;
        }
        else
        {
            _speed -= Drag;
        }

        _speed = Mathf.Clamp(_speed, 0.0f, MaxSpeed);

        if (_moveInputValue.x != 0.0f)
        {
            _turnDirection = _moveInputValue.x > 0 ? 1 : -1;

            // Make sure the rotation is inverted when moving backwards
            if (_direction == Vector3.back)
                _turnDirection *= -1;
        }
        else
        {
            _turnDirection = 0;
        }
        
        this.transform.Translate(_speed * Time.deltaTime * _direction);
        this.transform.Rotate(new Vector3(0.0f, _turnDirection * TurnSpeed, 0.0f));
    }

    private void LeaveGround()
    {
        if (_wheelControllers.All(x => x.IsTouchingGround == false))
            IsGrounded = false;
    }

    private void TouchGround()
    {
        if (_wheelControllers.Any(x => x.IsTouchingGround == true))
            IsGrounded = true;
    }

    private void Start()
    {
        _moveInput = InputSystem.actions.FindAction("Move");
        _speed = 0;

        foreach (var wheelController in _wheelControllers)
        {
            wheelController.OnTouchedGround += TouchGround;
            wheelController.OnLeftGround += LeaveGround;
        }
    }

    private void Update()
    {
        CalculateMovement();
    }
}
