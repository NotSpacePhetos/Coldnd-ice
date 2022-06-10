using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSwaper : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private GameObject _crosshair;

    [SerializeField] private KeyCode _pauseKey = KeyCode.Escape;
    [SerializeField] private KeyCode _inventoryKey = KeyCode.Tab;

    private void Update()
    {
        if (Input.GetKeyDown(_pauseKey))
        {
            if (_inventoryPanel.activeSelf)
            {
                _inventoryPanel.SetActive(false);
            }
            else
            {
                _pausePanel.SetActive(!_pausePanel.activeSelf);
                if (_pausePanel.activeSelf)
                {
                    StopGame();
                    _crosshair.SetActive(false);
                }
                else
                {
                    ContinueGame();
                    _crosshair.SetActive(true);
                }
            }
        }

        if (Input.GetKeyDown(_inventoryKey))
        {
            _inventoryPanel.SetActive(Time.timeScale == 1 && !_inventoryPanel.activeSelf);
            _crosshair.SetActive(Time.timeScale == 1 && !_inventoryPanel.activeSelf);
        }


    }

    private void StopGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }

    private void ContinueGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
