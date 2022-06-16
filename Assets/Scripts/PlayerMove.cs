using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _gravityScale = 9.81f;
    [SerializeField] private float _speed = 3;
    [SerializeField] private float _sprintSpeedAdd = 2;
    [SerializeField] private float _maxStamina = 100;
    [SerializeField] private float _staminaLossPerSecond = 20;
    [SerializeField] private float _staminaRegeneratePerSecond = 8;
    [SerializeField] private float _jumpForce = 5;
    [SerializeField] private float _jumpColdown = 0.3f;
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode _sprintKey = KeyCode.LeftShift;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _distanceToGround = 0.5f;
    [SerializeField] private float _defaultFallSpeed = 2;

    private float _stamina;
    private float _movmentSpeed;

    private bool _canJump = true;
    private bool _falled = false;

    private CharacterController _myController;

    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";
    private Vector2 _input = Vector2.zero;

    private Vector3 _velocity;

    private IEnumerator regenerator;

    private void Awake()
    {
        _myController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _stamina = _maxStamina;
        _movmentSpeed = _speed;
    }

    private void FixedUpdate()
    {
        if (CheckGround() == false)
        {
            Fall();
            _falled = false;
        }

        else
        {
            if (_falled == false)
            {
                _falled = true;
                StartCoroutine(JumpReload());
            }
            if (_canJump)
            {
                _velocity.y = -_defaultFallSpeed;
            }
            
        }

        Move();

    }

    private void Update()
    {
        if (Input.GetKeyDown(_jumpKey))
        {
            TryJump();
        }

        if (Input.GetKey(_sprintKey) && _stamina > 0)
        {
            Sprint();
        }

        else if (Input.GetKeyUp(_sprintKey))
        {
            _movmentSpeed = _speed;
            StartSprintReloading();
        }

        else
        {
            _movmentSpeed = _speed;
        }


        float x = Input.GetAxis(HorizontalAxis);
        float y = Input.GetAxis(VerticalAxis);

        _input = new Vector2(x, y);
    }

    private void StartSprintReloading()
    {
        if (regenerator != null)
        {
            StopCoroutine(regenerator);
        }

        regenerator = StaminaRegenerating();
        StartCoroutine(regenerator);
    }

    private void Sprint()
    {
        _movmentSpeed = _speed + _sprintSpeedAdd;
        _stamina -= _staminaLossPerSecond * Time.deltaTime;
    }

    private void Move()
    {
        _velocity = (transform.forward * _input.y + transform.right * _input.x) * _movmentSpeed + transform.up * _velocity.y;

        _myController.Move(_velocity * Time.fixedDeltaTime);
    }

    private void Fall()
    {
        _velocity.y -= _gravityScale * Time.fixedDeltaTime;
    }

    private void TryJump()
    {
        if (_canJump)
        {
            _velocity.y = _jumpForce;
            StartCoroutine(JumpReload());
        }
    }

    private IEnumerator StaminaRegenerating()
    {
        while (_stamina < _maxStamina)
        {
            _stamina += _staminaRegeneratePerSecond * Time.fixedDeltaTime;
            yield return null;
        }
    }

    private IEnumerator JumpReload()
    {
        _canJump = false;
        yield return new WaitForSeconds(_jumpColdown);
        _canJump = true;
    }

    private bool CheckGround()
    {
        return Physics.SphereCast(_groundChecker.position, _distanceToGround, -_groundChecker.up, out RaycastHit hit);
    }
}
