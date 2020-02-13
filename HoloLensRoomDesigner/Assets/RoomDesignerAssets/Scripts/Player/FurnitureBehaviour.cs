using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using UnityEngine.XR.WSA;

public class FurnitureBehaviour : MonoBehaviour
{
    public FurnitureType type;

    public float placeRange;
    
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
        DetectCollisions();
    }

    void DetectCollisions()
    {
        int layerMask = 1 << LayerMask.NameToLayer("SpatialSurface");
        Vector3[] directions = {Vector3.up, Vector3.down, Vector3.forward, Vector3.back, Vector3.left, Vector3.right};
        foreach (var dir in directions)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, dir, out hit, placeRange))
            {
                Debug.Log("Mesh Hit!");
            }
            Debug.DrawRay(transform.position,dir,Color.green, placeRange);
        }
    }


}
