using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    [HideInInspector] public GameObject currentObject;
    [SerializeField] private Camera _camera;
    private readonly float  SPAWNDISTANCE = 2;

    public ToolMode Tool { get; set; }
    // Start is called before the first frame update
    void Start()
    {
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

        bool hasCurrentObjectBeenTouched = currentObject && !currentObject.GetComponent<FurnitureBehaviour>().moved;
        if (hasCurrentObjectBeenTouched)
        {
            Destroy(currentObject);
        }
        
        currentObject = Instantiate(furniture, _camera.transform.position + new Vector3(0,0,SPAWNDISTANCE), Quaternion.identity);
        currentObject.GetComponent<FurnitureBehaviour>().Player = this;
    }
}
