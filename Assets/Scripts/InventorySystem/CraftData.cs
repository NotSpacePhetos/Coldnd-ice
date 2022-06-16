using System;
using System.Collections.Generic;
using UnityEngine;

public class CraftData : MonoBehaviour
{
    [Serializable] 
    public struct ItemAndNeedAmount
    {
        public PickupData item;
        public int amount;
    }

    public ItemAndNeedAmount[] craft;
    public int outAmount;
}
