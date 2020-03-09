using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBackToUI : MonoBehaviour
{
    [SerializeField] private ButtonPhotoMode buttonPhotoMode;

    public void ToggleUI()
    {
        buttonPhotoMode.ToggleUI();
    }
}
