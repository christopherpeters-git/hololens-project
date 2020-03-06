using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    [SerializeField] private float cellHeight;
    [SerializeField] private float cellWidth;
    [SerializeField] private float spaceVertical;
    [SerializeField] private float spaceHorizontal;
    [SerializeField] private int maxColumns;
    
    private GameObject[,] _grid;
    private int childCount;

    
    
    // Start is called before the first frame update
    void Start()
    {
        if (maxColumns <= 0)
        {
            throw new Exception("maxColumns is smaller than 1");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Initializes grid and sets positions of items in grid
    /// </summary>
    public void Init()
    {
        InitializeGrid();
        PopulateGrid();
        SetPositionOfItemsInGrid();
    }
    

    private void InitializeGrid()
    {
        foreach (Transform child in transform)
        {
            if(child.gameObject.CompareTag("InventoryItem"))
            {
                childCount++;
            }
        }
        int rows = (int) (childCount / maxColumns) + 1;
        _grid = new GameObject[rows, maxColumns];  
        //DisplayDebugInfos();
    }

    private void DisplayDebugInfos()
    {
        Debug.Log("Items: " + childCount);
        Debug.Log("Columns: " + (_grid.Length / _grid.GetLength(0)));
        Debug.Log("Rows: " + _grid.GetLength(0));
    }

    private void PopulateGrid()
    {   
        int countX = 0;
        int countY = 0;
        foreach (Transform child in transform)
        {
            if(child.gameObject.CompareTag("InventoryItem"))
            {
                _grid[countY, countX] = child.gameObject;
                countX++;
                if (countX >= maxColumns)
                {
                    countY++;
                    countX = 0;
                }
            } 
        } 
    }

    private void SetPositionOfItemsInGrid()
    {
        float offsetY = 0;
        for (int row = 0; row < _grid.GetLength(0) ; row++)
        {
            float offsetX = 0;
            for (int column = 0; column < maxColumns; column++)
            {
                if (_grid[row, column])
                { 
                    _grid[row, column].transform.position = new Vector3(offsetX, offsetY, 0.0f);
                    offsetX += spaceHorizontal + cellWidth;
                    Debug.Log(_grid[row,column].transform.position);
                }
            }
            offsetY -= cellHeight + spaceVertical;
        }

    }
    
    public void ScrollDown()
    {
        
    }

    public void ScrollUp()
    {
        
    }
}
