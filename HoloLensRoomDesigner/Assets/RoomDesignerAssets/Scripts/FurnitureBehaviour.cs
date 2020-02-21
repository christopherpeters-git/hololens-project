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
    public FurnitureType type;
    
    public bool moved { get; set; }

    private ManipulationHandler _manipulationHandler;

    public String name;

    public float SurfaceMountDistance;

    private SurfaceMagnetism _magnet;

    private Rigidbody _rigid;

    public PlayerBehaviour Player { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        moved = false;
        if (type == FurnitureType.NONE)
        {
            type = FurnitureType.FLOOR;
        }

        _rigid = GetComponent<Rigidbody>();
        _magnet = GetComponent<SurfaceMagnetism>();
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
        ControlRigidBody();
    }
    void OnCollisionExit(Collision other)
    {
        ResetForce();
    }
    
    public void ResetForce()
    {
        _rigid.AddForce(Vector3.zero);
    }

    void ControlRigidBody()
    {
        if (IsNearToPreferredSurface())
        {
            ResetForce();
            _rigid.useGravity = false;
        }
        else
        {
            _rigid.useGravity = true;
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
