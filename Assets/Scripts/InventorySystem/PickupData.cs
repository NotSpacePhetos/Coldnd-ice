using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CraftData))]
public class PickupData : InteractiveObject
{
    public string id;
    public string nameItem;
    public int stackSize = 1;
    public int amount = 1;

    public CraftData craft { get; private set; }

    private void Awake()
    {
        craft = GetComponent<CraftData>();
    }

    public override void Interactive(GameObject player)
    {
        if (player.TryGetComponent(out PlayerViewer inventoryHeaver))
        {
            inventoryHeaver.inventory.AddItem(this);
        }
    }
}
