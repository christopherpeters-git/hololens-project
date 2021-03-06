﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float  _spawnDistance = 2;
    
    [HideInInspector] public GameObject currentObject;
    [HideInInspector] public List<GameObject> instantiatedObjects;
    
    /// <summary>
    /// To make this script a singleton
    /// </summary>
    private static PlayerBehaviour _instance;
    
    public ToolMode Tool { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        if (!_instance)
        {
            _instance = this;
        }
        else
        {
            throw new Exception("Only one PlayerBehaviour is allowed!");
        }
        instantiatedObjects = new List<GameObject>();
        Tool = ToolMode.EDIT;
        _camera = GetComponentInParent<Camera>();
    }

    /// <summary>
    /// Spawns a new piece of furniture
    /// </summary>
    /// <param name="furniture"></param>
    public void SpawnFurniture(GameObject furniture)
    {
        FurnitureBehaviour furnitureBehaviour = furniture.GetComponent<FurnitureBehaviour>();
        if (!furnitureBehaviour)
        {
            throw new ArgumentException("That object was no furniture. Wrong Prefab listed?");
        }

        bool hasCurrentObjectBeenTouched = currentObject && !currentObject.GetComponent<FurnitureBehaviour>().Moved;
        if (hasCurrentObjectBeenTouched)
        {
            instantiatedObjects.Remove(currentObject);
            Destroy(currentObject);
        }
        
        currentObject = Instantiate(furniture, _camera.transform.position + new Vector3(0,0,_spawnDistance), Quaternion.identity);
        currentObject.GetComponent<FurnitureBehaviour>().Player = this;
        instantiatedObjects.Add(currentObject);
    }
}
