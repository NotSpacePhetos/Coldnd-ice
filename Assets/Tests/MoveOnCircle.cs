using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestScripts
{
    public class MoveOnCircle : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _radius = 1;

        private Vector3 _startPosition;

        private void Start()
        {
            _startPosition = transform.position;
        }

        void Update()
        {
            transform.position = _startPosition + new Vector3(_radius * Mathf.Cos(Time.time * _speed), 0, _radius * Mathf.Sin(Time.time * _speed));
        }
    }
}
