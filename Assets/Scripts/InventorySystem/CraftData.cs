using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftData : MonoBehaviour
{
    [SerializeField] public Dictionary<PickupData, int>[] needItemsAndAmount;

    public int outAmount;
}
