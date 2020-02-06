using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public GameObject currentObject;

    public EditMode Mode { set; get; }
    // Start is called before the first frame update
    void Start()
    {
        Mode = EditMode.MOVE;
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
