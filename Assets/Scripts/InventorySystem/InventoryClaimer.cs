using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryClaimer: MonoBehaviour
{
    [SerializeField] private float _defaultScaleObjectInCanvas;
    [SerializeField] private GridLayoutGroup _inventoryGrid;
    [SerializeField] private GameObject _itemBoxPrefab;
    [SerializeField] private int _UILayer;

    public List<PickupData> _pickups;

    public void AddItem(PickupData item)
    {
        while (FindFreeSimilarItem(item.id) != null && item.amount > 0)
        {
            PickupData currentFreeItem = FindFreeSimilarItem(item.id);
            int neededCurrentItemAmountToStack = currentFreeItem.stackSize - currentFreeItem.amount;
            int addAmount;
            if (neededCurrentItemAmountToStack >= item.amount)
            {
                addAmount = item.amount;
            }
            else
            {
                addAmount = item.amount - (item.amount - neededCurrentItemAmountToStack);
            }

            currentFreeItem.amount += addAmount;
            item.amount -= addAmount;
        }

        if (item.amount > 0)
        {
            GameObject box = _itemBoxPrefab;
            item.transform.localScale = Vector3.one * _defaultScaleObjectInCanvas;
            box = Instantiate(box, _inventoryGrid.transform);
            PickupData addedItem = Instantiate(item, box.transform);
            _pickups.Add(addedItem);
            SetLayerDefaultInChilds(box.transform);
        }
        Destroy(item.gameObject);
    }

    private PickupData FindFreeSimilarItem(string pickupId)
    {
        foreach (PickupData pickup in _pickups)
        {
            if (pickup.id == pickupId && pickup.amount < pickup.stackSize)
            {
                return pickup;
            }
        }
        return null;
    }

    private void SetLayerDefaultInChilds(Transform parent)
    {
        foreach (Transform child in parent.GetComponentsInChildren<Transform>())
        {
            child.gameObject.layer = _UILayer;
        }
    }
}
