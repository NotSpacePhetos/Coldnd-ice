using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewer : MonoBehaviour
{
    [SerializeField] private Transform _myHead;
    [SerializeField] private float _sensevity = 3;

    [SerializeField] private float _rotationSmooth = 0.5f;

    [SerializeField] private float _minVerticalRotation = -80;
    [SerializeField] private float _maxVerticalRotation = 80;

    private const string MouseAxisX = "Mouse X";
    private const string MouseAxisY = "Mouse Y";

    private float _horizontalRotation;
    private float _verticalRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        RotateHeadAndBody();
    }

    private void RotateHeadAndBody()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw(MouseAxisX), Input.GetAxisRaw(MouseAxisY));

        _horizontalRotation += input.x * Time.deltaTime * _sensevity;
        _verticalRotation -= input.y * Time.deltaTime * _sensevity;

        _verticalRotation = Mathf.Clamp(_verticalRotation, _minVerticalRotation, _maxVerticalRotation);

        _myHead.localRotation = Quaternion.Slerp(_myHead.localRotation, Quaternion.AngleAxis(_verticalRotation, Vector3.right), _rotationSmooth * Time.deltaTime);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(_horizontalRotation, Vector3.up), _rotationSmooth * Time.deltaTime);
    }
}
