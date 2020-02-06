using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField] private Text _editorMode;

    private PlayerBehaviour _player;

    private EditMode _oldMode = EditMode.NONE;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEditorInfoText();
    }
    
    

    private void UpdateEditorInfoText()
    {
        if (!(_player.Mode == _oldMode))
        {
            _editorMode.text = "Tool: " + _player.Mode;
        }
        _oldMode = _player.Mode;
    }
    
}
