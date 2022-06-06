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
        [SerializeField] private GameObject _optionsPlanel;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _optionsButton;
        [SerializeField] private Button _exitButton;

        private bool _isPause = false;

        private void Start()
        {
            ButtonsOnClickInit();
            _pauseMenuPlanel.SetActive(false);
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
            _optionsButton.onClick.AddListener(OpenOptions);
        }

        private void SwitchPauseState()
        {
            _isPause = !_isPause;
            _pauseMenuPlanel.SetActive(_isPause);
            if (_isPause)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        private void OpenOptions()
        {
            _optionsPlanel.SetActive(true);
        }
    }
}


