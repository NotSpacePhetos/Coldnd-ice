using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestScripts
{

    public class PlayerSpawn : MonoBehaviour
    {
        [SerializeField] private PlayerPickuper _playerPrefab;
        [SerializeField] private Inventory _inventory;

        private void Start()
        {
            PlayerPickuper player = Instantiate(_playerPrefab, transform.position, Quaternion.identity);
            player.inventory = _inventory;
        }
    }

}


