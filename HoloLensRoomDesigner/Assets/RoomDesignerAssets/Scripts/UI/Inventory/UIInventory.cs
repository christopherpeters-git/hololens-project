using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> _furniturePieces;
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private GameObject _contentWindow;

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
        InventoryGrid collection = _contentWindow.GetComponent<InventoryGrid>();
        
        foreach (var piece in _furniturePieces)
        {
            GameObject newButton = Instantiate(_buttonPrefab,_contentWindow.transform);
            newButton.GetComponentInChildren<TextMeshPro>().text = piece.GetComponent<FurnitureBehaviour>().name;
            newButton.GetComponent<Interactable>().OnClick.AddListener(() => _player.SpawnFurniture(piece));
        }
        collection.Init();
    }
}
