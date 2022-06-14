using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CanvasMethods : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuPlanel;
    [SerializeField] private GameObject _optionsPlanel;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        ButtonsOnClickInit();
        _pauseMenuPlanel.SetActive(false);
    }

    private void ButtonsOnClickInit()
    {
        _continueButton.onClick.AddListener(Continue);
        _optionsButton.onClick.AddListener(OpenOptions);
    }

    private void Continue()
    {
        _pauseMenuPlanel.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OpenOptions()
    {
        _optionsPlanel.SetActive(true);
    }
}



