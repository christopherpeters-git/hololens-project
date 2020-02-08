using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public GameObject currentObject;

    private Camera _camera;
    
    private readonly float  SPAWNDISTANCE = 1;

    public EditMode Mode { set; get; }
    // Start is called before the first frame update
    void Start()
    {
        Mode = EditMode.MOVE;
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
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
