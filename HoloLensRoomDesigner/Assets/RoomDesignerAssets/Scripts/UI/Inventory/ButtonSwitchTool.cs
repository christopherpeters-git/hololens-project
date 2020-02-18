using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitchTool : MonoBehaviour
{
    [SerializeField] private UITools _uiTools;
    // Start is called before the first frame update
    public void SwitchTool()
    {
        _uiTools.SwitchToolMode();
    }
}
