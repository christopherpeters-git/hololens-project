using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class UIFollowTarget : MonoBehaviour
{
    [SerializeField] private bool useStartOffset;
    [SerializeField] private Transform target;
    [Header("Custom offset")]
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetZ;
    
    private Vector3 _offset;
    // Update is called once per frame

    private void Start()
    {
        _offset = transform.position - target.position;
    }

    void Update()
    {
        FollowTarget();
    }

    /// <summary>
    /// Makes this Object Follow the player with an offset set by the start
    /// </summary>
    private void FollowTarget()
    {
        if (useStartOffset)
        {
            transform.position = target.position + _offset;
        }
        else
        {
            transform.position = target.position +  new Vector3(offsetX,offsetY,offsetZ);
        }
    }
}
