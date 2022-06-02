using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 3;

    private Rigidbody _myPhysic;

    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    private void Awake()
    {
        _myPhysic = GetComponent<Rigidbody>();
        _myPhysic.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 input = new Vector2(Input.GetAxis(HorizontalAxis), Input.GetAxis(VerticalAxis));

        Vector3 moveDirection = (input.x * transform.right + input.y * transform.forward) * _speed;
        moveDirection.y = _myPhysic.velocity.y;
        _myPhysic.velocity = moveDirection;
    }
}
