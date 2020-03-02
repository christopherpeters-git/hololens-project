using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Experimental.Utilities;
using UnityEngine;

[Serializable]
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float  _spawnDistance = 2;
    [SerializeField] private WorldAnchorManager _worldAnchorManager;
    
    [HideInInspector] public GameObject currentObject;
    [HideInInspector] public List<GameObject> instantiatedObjects;
    
    /// <summary>
    /// To make this script a singleton
    /// </summary>
    private static PlayerBehaviour _instance;
    /// <summary>
    /// To serialize the gameState
    /// </summary>
    public static GameObject playerObject;
    
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
        playerObject = gameObject;
        _worldAnchorManager = GetComponent<WorldAnchorManager>();
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
        FurnitureBehaviour currentFurnitureBehaviour = currentObject.GetComponent<FurnitureBehaviour>();
        currentFurnitureBehaviour.SetId();
        currentFurnitureBehaviour.Player = this;
        currentFurnitureBehaviour.WorldAnchorManager = _worldAnchorManager;
        instantiatedObjects.Add(currentObject);
    }
}
