using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 _offset;
    // Update is called once per frame

    private void Start()
    {
        _offset = transform.position - _target.position;
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
        transform.position = _target.position + _offset;
    }
}
