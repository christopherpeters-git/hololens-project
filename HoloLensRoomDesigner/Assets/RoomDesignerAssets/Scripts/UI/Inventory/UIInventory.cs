using System;
using System.Collections;
using System.Collections.Generic;
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
        float xOffset = 0;
        foreach (var piece in _furniturePieces)
        {
            GameObject newButton = Instantiate(_buttonPrefab, new Vector3(xOffset - 0.125f,0.125f,0.4f), Quaternion.identity, _contentWindow.transform);
            newButton.GetComponentInChildren<TextMeshPro>().text =
                piece.GetComponent<FurnitureBehaviour>().name;
            newButton.GetComponent<Interactable>().OnClick.AddListener(() => _player.SpawnFurniture(piece));
            xOffset += 0.175f;
        }
    }
}
