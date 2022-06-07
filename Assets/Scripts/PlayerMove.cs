using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _gravityScale = 9.81f;
    [SerializeField] private float _movmentSpeed = 3;
    [SerializeField] private float _jumpForce;
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _distanceToGround;

    private CharacterController _myController;

    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";
    private Vector3 _input
    {
        get
        {
            float x = Input.GetAxis(HorizontalAxis);
            float y = Input.GetAxis(VerticalAxis);

            return new Vector2(x, y);
        }
    }

    private Vector3 _velocity;

    private void Awake()
    {
        _myController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (CheckGround() == false)
        {
            Fall();
        }

        else
        {
            _velocity.y = 0;
            if (Input.GetKeyDown(_jumpKey))
            {
                Jump();
            }
        }
        
        Move();
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

    private void Jump()
    {
        _velocity.y = _jumpForce;
    }

    private bool CheckGround()
    {
        return Physics.Raycast(_groundChecker.position, -_groundChecker.up, _distanceToGround);
    }
}
