using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwaper : MonoBehaviour
{
    [SerializeField] private Transform _holster;
    [SerializeField] private Dictionary<ItemBox, GunData>[] _gunSlots; 

}
