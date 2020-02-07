using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class FurnitureBehaviour : MonoBehaviour
{
    public FurnitureType type;
    // Start is called before the first frame update
    void Start()
    {
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
