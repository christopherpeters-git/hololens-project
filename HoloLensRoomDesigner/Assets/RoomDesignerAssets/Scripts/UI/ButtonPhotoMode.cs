using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class ButtonPhotoMode : MonoBehaviour
{
    private HideInPhotoMode[] _itemsToHide;
    [SerializeField] private GameObject buttonBackToUI;
    private bool _isInPhotoMode = false;
    private PlayerBehaviour _player;

    public void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
        _itemsToHide = FindObjectsOfType<HideInPhotoMode>();
    }

    /// <summary>
    /// Called by Button; Toggles the UI for screenshots
    /// </summary>
    public void ToggleUI()
    {
        if (!_isInPhotoMode)
        {
           SetBoundingBoxesVisibility(false);
           foreach (var item in _itemsToHide)
           {
               item.gameObject.SetActive(false);
               
           }
           buttonBackToUI.SetActive(true);
           _isInPhotoMode = true;
        }
        else
        {
            buttonBackToUI.SetActive(false);
            foreach (var item in _itemsToHide)
            {
                item.gameObject.SetActive(true);
            }
            SetBoundingBoxesVisibility(true);
            _isInPhotoMode = false;
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
