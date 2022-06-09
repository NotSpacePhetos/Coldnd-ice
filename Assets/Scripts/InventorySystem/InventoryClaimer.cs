using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryClaimer : MonoBehaviour
{
    [SerializeField] private float _defaultScaleObjectInCanvas;
    [SerializeField] private GridLayoutGroup _inventoryGrid;
    [SerializeField] private GameObject _itemBoxPrefab;
    [SerializeField] private int _UILayer;
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private KeyCode _openInventoryKey = KeyCode.Tab;

    public List<PickupData> _items;

    private void Update()
    {
        if (Input.GetKeyDown(_openInventoryKey))
        {
            _inventoryPanel.SetActive(Time.timeScale == 1 && !_inventoryPanel.activeSelf);
        }
    }

    public void AddItem(PickupData item)
    {
        GameObject box = _itemBoxPrefab;
        item.transform.localScale = Vector3.one * _defaultScaleObjectInCanvas;
        box = Instantiate(box, _inventoryGrid.transform);
        PickupData addedItem = Instantiate(item, box.transform);
        _items.Add(addedItem);
        SetLayerDefaultInChilds(box.transform);

        Destroy(item.gameObject);
    }

    private void SetLayerDefaultInChilds(Transform parent)
    {
        foreach(Transform child in parent.GetComponentsInChildren<Transform>())
        {
            child.gameObject.layer = _UILayer;
        }
    }
}
