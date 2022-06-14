using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(Rigidbody), typeof(NavMeshAgent))]
public class WoolfAI : MonoBehaviour
{
    [SerializeField] private float _rangeDetect = 4;
    [SerializeField] private int _raysCount = 5;
    [SerializeField] private float _fieldAngel = 90;
    [SerializeField] private float _checkRate = 2;
    [SerializeField] private Transform _viewer;
    [SerializeField] private float _speedDefault = 2;
    [SerializeField] private float _speedRage = 5;
    [SerializeField] private float _raportDistance = 3;
    [SerializeField] private Point[] _movePoints;

    private int _currentPoint;
    private Rigidbody _moveAgent;
    private NavMeshAgent _navMoveAgent;
    public States _currentState { get; private set; } = States.relax;
    private Transform _target = null;

    public enum States
    {
        relax = 0,
        rage = 1
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Point point) && point == _movePoints[_currentPoint])
        {
            _currentPoint++;
            _currentPoint %= _movePoints.Length;
        }
    }

    private void Awake()
    {
        _moveAgent = GetComponent<Rigidbody>();
        _navMoveAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        StartCoroutine(Checking());
        GoIntoARelax();
    }

    private void Update()
    {
        switch (_currentState)
        {
            case States.relax:
                _navMoveAgent.SetDestination(_movePoints[_currentPoint].transform.position);
                break;
            case States.rage:
                _navMoveAgent.SetDestination(_target.position);
                break;
        }
    }

    private bool Check(out Transform target)
    {
        Transform helpObject = Instantiate(new GameObject("helper"), _viewer.position, _viewer.rotation).transform;
        for (int ray = 0; ray < _raysCount; ray++)
        {
            float currentAngle = _fieldAngel / 2 - _fieldAngel / (_raysCount - 1) * ray;
            helpObject.rotation = _viewer.rotation;
            helpObject.Rotate(_viewer.up, currentAngle);
            Vector3 currentDirection = helpObject.forward;
            bool hited = Physics.Raycast(_viewer.position, currentDirection, out RaycastHit hit, _rangeDetect);

            if (hited && hit.collider.gameObject.TryGetComponent(out Player player))
            {
                Destroy(helpObject.gameObject);
                target = player.transform;
                return true;
            }
        }
        Destroy(helpObject.gameObject);
        target = null;
        return false;
    }

    private IEnumerator Checking()
    {
        while (true)
        {
            yield return new WaitForSeconds(_checkRate);
            if (Check(out Transform player))
            {
                GoIntoARage(player);
            }
        }
    }

    

    public void GoIntoARage(Transform target)
    {
        _currentState = States.rage;
        _navMoveAgent.speed = _speedRage;
        _target = target;
        foreach (RaycastHit obj in Physics.SphereCastAll(_viewer.position, _raportDistance, _viewer.up))
        {
            if (obj.collider.gameObject.TryGetComponent(out WoolfAI woolf) && woolf._currentState != States.rage)
            {
                woolf.GoIntoARage(target);
            }
        }
    }

    private void GoIntoARelax()
    {
        _currentState = States.relax;
        _navMoveAgent.speed = _speedDefault;
        _target = null;
    }

    public class PointPattern
    {
        public float stayTime = 1;
    }
}
