using UnityEngine;
using System;

[Serializable]
public class InventoryItem : MonoBehaviour
{
    public PickupData data { private set; get; }
    public int amount { private set; get; }

    public InventoryItem(PickupData source)
    {
        data = source;

    }

    public void AddItemToStack()
    {
        amount++;
    }

    public void RemoveItemToStack()
    {
        amount--;
    }
}
