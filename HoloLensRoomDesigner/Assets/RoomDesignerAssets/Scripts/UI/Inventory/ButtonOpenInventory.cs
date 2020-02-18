using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOpenInventory : MonoBehaviour
{
    [SerializeField] private GameObject _inventory;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForInventoryInit());
    }

    private IEnumerator WaitForInventoryInit()
    {
        yield return new WaitUntil(() => _inventory);
        _inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /// <summary>
    /// Toggles inventory by enabling/disabling gameobject
    /// </summary>
    public void ToggleInventory()
    {
        if (_inventory.activeSelf)
        {
            _inventory.SetActive(false);
        }
        else
        {
            _inventory.SetActive(true);
        }
    }
}
