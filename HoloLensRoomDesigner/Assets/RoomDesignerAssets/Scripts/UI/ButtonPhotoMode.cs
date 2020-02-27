using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class ButtonPhotoMode : MonoBehaviour
{
    [SerializeField] private GameObject _ui;
    [SerializeField] private GameObject _buttonBackToUI;
    private bool _isInPhotoMode;
    private PlayerBehaviour _player;

    public void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
    }

    /// <summary>
    /// Called by Button; Toggles the UI for screenshots
    /// </summary>
    public void ToggleUI()
    {
        if (_ui.activeSelf)
        {
           SetBoundingBoxesVisibility(false);
            _ui.SetActive(false);
            _buttonBackToUI.SetActive(true);
        }
        else
        {
            _buttonBackToUI.SetActive(false);
            _ui.SetActive(true);
            SetBoundingBoxesVisibility(true);
        }
    }

    private void SetBoundingBoxesVisibility(bool isVisible)
    {
        foreach (var furniturePiece in _player.instantiatedObjects)
        {
            furniturePiece.GetComponent<BoundingBox>().Active = isVisible;
        }
    }
}
