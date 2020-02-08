using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class FurnitureBehaviour : MonoBehaviour
{
    public FurnitureType type;
    
    public bool moved { get; set; }

    public String name;
    // Start is called before the first frame update
    void Start()
    {
        moved = false;
        if (type == FurnitureType.NONE)
        {
            type = FurnitureType.FLOOR;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
