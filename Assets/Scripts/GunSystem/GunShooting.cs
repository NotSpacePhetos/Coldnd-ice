using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GunData))]
public class GunShooting : MonoBehaviour
{
    public Player owner;

    [SerializeField] private KeyCode _shootKey = KeyCode.Mouse0;

    private GunData _gunSettings;
    private bool _canShoot = true;

    private void Awake()
    {
        _gunSettings = GetComponent<GunData>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_shootKey))
        {
            TryShoot();
        }
    }

    private void TryShoot()
    {
        Transform viewer = Camera.main.transform;
        if (_canShoot && Physics.Raycast(viewer.position, viewer.forward, out RaycastHit hit, _gunSettings.range))
        {
            if (hit.collider.gameObject.TryGetComponent(out EntityBase entity) && entity != owner)
            {
                entity.Hit(_gunSettings.damage);
                Recovery();
            }
        }
    }

    private void Recovery()
    {
        StartCoroutine(Recovering());
    }

    private IEnumerator Recovering()
    {
        _canShoot = false;
        yield return new WaitForSeconds(_gunSettings.fireRate);
        _canShoot = true;
    }
}
