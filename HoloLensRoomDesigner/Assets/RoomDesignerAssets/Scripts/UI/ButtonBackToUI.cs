using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBackToUI : MonoBehaviour
{
    [SerializeField] private ButtonPhotoMode _photoMode;

    public void ToggleUI()
    {
        _photoMode.ToggleUI();
    }
}
