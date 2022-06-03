using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestScripts
{
    public class CanvasMethods : MonoBehaviour
    {
        [SerializeField] private KeyCode _pauseKey = KeyCode.Escape;
        [SerializeField] private GameObject _pauseMenuPlanel;

        private void Start()
        {
            ButtonsOnClickInit();
        }

        private void Update()
        {
            if (Input.GetKeyDown(_pauseKey))
            {
                Time.timeScale = 0;
                _pauseMenuPlanel.SetActive(false);
            }
        }

        private void ButtonsOnClickInit()
        {

        }
    }
}


