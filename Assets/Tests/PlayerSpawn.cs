using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestScripts
{

    public class PlayerSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;

        private void Start()
        {
            Instantiate(_playerPrefab, transform.position, Quaternion.identity);
        }
    }

}


