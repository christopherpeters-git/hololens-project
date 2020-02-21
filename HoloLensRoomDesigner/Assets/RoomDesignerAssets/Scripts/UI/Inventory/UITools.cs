using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITools : MonoBehaviour
{
    [SerializeField] private TextMeshPro _toolInfo;
    [SerializeField] private PlayerBehaviour _player;
    [SerializeField] private List<GameObject> _editModeobjects;

    
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerBehaviour>();
        DisplayToolInText();
    }
    
    public void SwitchToolMode()
    {
        if (_player.Tool + 1 != ToolMode.NONE)
        {
            _player.Tool += 1;
        }
        else
        {
            _player.Tool = ToolMode.EDIT;
        }
        DisplayToolInText();
        SwitchState();
    }

    private void SetStatusOfAllComponents(bool status)
    {
        foreach (var editObject in _editModeobjects)
        {
            if (editObject)
            {
                editObject.SetActive(status);
            }
        }
    }

    private void SwitchState()
    {
        switch (_player.Tool)
        {
            case ToolMode.EDIT:
              SetStatusOfAllComponents(true);
                break;
            case ToolMode.REMOVE:
                SetStatusOfAllComponents(false);
              break;
            case ToolMode.NONE:
                break;
        }
    }

    private void DisplayToolInText()
    {
        String text = "switch mode\n current mode: " + _player.Tool.ToString();
        _toolInfo.text = text;
    }
}
