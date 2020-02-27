using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEngine;
using UnityEngine.XR.WSA;

public class FurnitureBehaviour : MonoBehaviour
{
    private static int _maxId = 0;
    private static int id;
    
    public FurnitureType type;
    public bool moved { get; set; }
    public String name;
    public float SurfaceMountDistance;

    private Outline _outline;
    


    public PlayerBehaviour Player { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        _outline = GetComponent<Outline>();
        SetId();
        moved = false;
        if (type == FurnitureType.NONE)
        {
            type = FurnitureType.FLOOR;
        }
    }

    public void AddAsWorldAnchor()
    {
        
    }

    public void RemoveAsWorldAnchor()
    {
        
    }

    private void SetId()
    {
        id = _maxId;
        _maxId++;
    }

    public void DestroyOnRemove()
    {
        if (Player.Tool == ToolMode.REMOVE)
        {
            Player.currentObject = null;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        OutlineIfNearSurfaceType();
    }

    private void OutlineIfNearSurfaceType()
    {
        if (IsNearToPreferredSurface())
        {
            _outline.enabled = false;
        }
        else
        {
            _outline.enabled = true;
        }
    }
    
    
    private bool IsNearToPreferredSurface()
    {
        Vector3 position = transform.position;
        bool hitSurface = false;
        switch (type)
        {
            case FurnitureType.WALL:
                hitSurface = Physics.Raycast(position, transform.forward,SurfaceMountDistance) ||
                             Physics.Raycast(position, -transform.forward,SurfaceMountDistance) ||
                             Physics.Raycast(position, transform.right,SurfaceMountDistance) ||
                             Physics.Raycast(position, -transform.right,SurfaceMountDistance);
                Debug.DrawRay(position,transform.forward * SurfaceMountDistance, Color.red);
                break;
            case FurnitureType.CEILING:
                hitSurface = Physics.Raycast(position, transform.up,SurfaceMountDistance);
                Debug.DrawRay(position,transform.up * SurfaceMountDistance, Color.red,SurfaceMountDistance);
                break;
            case FurnitureType.FLOOR:
                hitSurface = Physics.Raycast(position, -transform.up,SurfaceMountDistance);
                Debug.DrawRay(position,-transform.up * SurfaceMountDistance, Color.red);
                break;
            case FurnitureType.NONE:
                hitSurface = true;
                break;
        }
        return hitSurface;
    }    
}
