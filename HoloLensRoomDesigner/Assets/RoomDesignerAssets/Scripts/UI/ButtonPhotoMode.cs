using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPhotoMode : MonoBehaviour
{
    [SerializeField] private GameObject _ui;
    [SerializeField] private GameObject _buttonBackToUI;
    private bool _isInPhotoMode;

    /// <summary>
    /// Called by Button; Toggles the UI for screenshots
    /// </summary>
    public void ToggleUI()
    {
        if (_ui.activeSelf)
        {
            _ui.SetActive(false);
            _buttonBackToUI.SetActive(true);
        }
        else
        {
            _buttonBackToUI.SetActive(false);
            _ui.SetActive(true);
        }
    }
}
