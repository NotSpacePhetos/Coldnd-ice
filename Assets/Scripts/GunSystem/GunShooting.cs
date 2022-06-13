using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GunData))]
public class GunShooting : MonoBehaviour
{
    [SerializeField] private KeyCode _shootKey = KeyCode.Mouse0;
    [SerializeField] private Transform _camera;

    public GunData currentGun;

    private void Update()
    {
        if (currentGun!= null && Input.GetKeyDown(_shootKey))
        {
            Shoot();
        }
    }

    private void Shoot()
    {

    }
}
