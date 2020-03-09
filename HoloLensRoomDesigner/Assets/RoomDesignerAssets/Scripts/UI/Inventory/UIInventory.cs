using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> furniturePieces;
    [SerializeField] private GameObject itemButtonPrefab;
    [SerializeField] private GameObject contentWindow;

    private PlayerBehaviour _player;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerBehaviour>();
        if (!_player) throw new Exception("No PlayerBehaviour found!");
        FillInventory();
    }

    /// <summary>
    /// Fills up content-page with a button for every single furniture-piece
    /// </summary>
    private void FillInventory()
    {
        InventoryGrid collection = contentWindow.GetComponent<InventoryGrid>();
        
        foreach (var piece in furniturePieces)
        {
            GameObject newButton = Instantiate(itemButtonPrefab,contentWindow.transform);
            newButton.GetComponentInChildren<TextMeshPro>().text = piece.GetComponent<FurnitureBehaviour>().name;
            newButton.GetComponent<Interactable>().OnClick.AddListener(() => _player.SpawnFurniture(piece));
        }
        collection.Init();
    }
}
