using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickuper : MonoBehaviour
{
    public InventoryClaimer inventory;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _pickupDistance = 1f;
    [SerializeField] private KeyCode _pickupKey = KeyCode.E;
    [SerializeField] private LayerMask _itemsLayer;

    private void Update()
    {
        if (Physics.Raycast(_camera.position, _camera.forward, out RaycastHit hit, _pickupDistance, _itemsLayer))
        {
            if (hit.collider.gameObject.TryGetComponent(out PickupData pd))
            {
                if (Input.GetKeyDown(_pickupKey))
                {
                    inventory.AddItem(pd);
                }
            }
        }
    }
}
