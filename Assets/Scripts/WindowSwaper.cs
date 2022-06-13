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
                SetInventoryPanelActiveState(false);
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
            SetInventoryPanelActiveState(Time.timeScale == 1 && !_inventoryPanel.activeSelf);
        }


    }

    private void SetInventoryPanelActiveState(bool state)
    {
        _inventoryPanel.SetActive(state);
        if (state)
        {
            _crosshair.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            _crosshair.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
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
