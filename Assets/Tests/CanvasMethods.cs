using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestScripts
{
    public class CanvasMethods : MonoBehaviour
    {
        [SerializeField] private KeyCode _pauseKey = KeyCode.Escape;
        [SerializeField] private GameObject _pauseMenuPlanel;
        [SerializeField] private Button _continueButton;

        private bool _isPause = false;

        private void Start()
        {
            ButtonsOnClickInit();
        }

        private void Update()
        {
            if (Input.GetKeyDown(_pauseKey))
            {
                SwitchPauseState();
            }
        }

        private void ButtonsOnClickInit()
        {
            _continueButton.onClick.AddListener(SwitchPauseState);
        }

        private void SwitchPauseState()
        {
            _isPause = !_isPause;
            _pauseMenuPlanel.SetActive(_isPause);
            if (_isPause)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}


