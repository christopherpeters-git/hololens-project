using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    private PlayerBehaviour _player;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEditMode(int editMode)
    {
        _player.Mode = (EditMode) editMode;
        Debug.Log("Mode: " + (EditMode)(editMode));
    }
    
}
