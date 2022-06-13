using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GunData))]
public class GunShooting : MonoBehaviour
{
    [SerializeField] private KeyCode _shootKey = KeyCode.Mouse0;

    private GunData _gunSettings;

    private void Awake()
    {
        _gunSettings = GetComponent<GunData>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_shootKey))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        
    }
}
