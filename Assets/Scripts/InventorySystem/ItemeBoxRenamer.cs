using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemeBoxRenamer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _namePickupLabel;

    private void Start()
    {
        PickupData item = transform.GetComponentInChildren<PickupData>();
        string name = item.nameItem;
        _namePickupLabel.text = name;
    }
}
