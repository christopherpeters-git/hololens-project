using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Experimental.Utilities;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEngine;
using UnityEngine.XR.WSA;

public class FurnitureBehaviour : MonoBehaviour
{
    public FurnitureType type;
    public bool Moved { get; set; }
    public new String name;
    public float surfaceMountDistance;

    private static int maxId = 0;
    private static int id;

    private Outline _outline;

    public WorldAnchorManager WorldAnchorManager { private get; set; }
    public PlayerBehaviour Player { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        _outline = GetComponent<Outline>();
        SetId();
        Moved = false;
        if (type == FurnitureType.NONE)
        {
            type = FurnitureType.FLOOR;
        }
    }

    public void AddAsWorldAnchor()
    {
        WorldAnchorManager.AttachAnchor(gameObject, id.ToString());
    }

    public void RemoveAsWorldAnchor()
    {
        WorldAnchorManager.RemoveAnchor(id.ToString());
    }

    public void SetId()
    {
        id = maxId;
        maxId++;
    }

    public void DestroyOnRemove()
    {
        if (Player.Tool == ToolMode.REMOVE)
        {
            if (Player.currentObject == gameObject)
            {
                Player.currentObject = null;
            }
            Player.instantiatedObjects.Remove(gameObject);
            WorldAnchorManager.RemoveAnchor(id.ToString());
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
                hitSurface = Physics.Raycast(position, transform.forward,surfaceMountDistance) ||
                             Physics.Raycast(position, -transform.forward,surfaceMountDistance) ||
                             Physics.Raycast(position, transform.right,surfaceMountDistance) ||
                             Physics.Raycast(position, -transform.right,surfaceMountDistance);
                Debug.DrawRay(position,transform.forward * surfaceMountDistance, Color.red);
                break;
            case FurnitureType.CEILING:
                hitSurface = Physics.Raycast(position, transform.up,surfaceMountDistance);
                Debug.DrawRay(position,transform.up * surfaceMountDistance, Color.red,surfaceMountDistance);
                break;
            case FurnitureType.FLOOR:
                hitSurface = Physics.Raycast(position, -transform.up,surfaceMountDistance);
                Debug.DrawRay(position,-transform.up * surfaceMountDistance, Color.red);
                break;
            case FurnitureType.NONE:
                hitSurface = true;
                break;
        }
        return hitSurface;
    }    
}
