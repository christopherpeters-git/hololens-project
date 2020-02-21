using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FurnitureType))]
public class FurnitureController : MonoBehaviour
{
    private FurnitureBehaviour _behaviour;
    // Start is called before the first frame update
    void Start()
    {
        _behaviour = GetComponent<FurnitureBehaviour>();
    }

    public void HasMoved(bool moved)
    {
        _behaviour.moved = true;
    }
}
