using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    [SerializeField] private int visibleRows;
    [SerializeField] private int maxColumns;
    
    [Header("Layout")]
    [SerializeField] private float cellHeight;
    [SerializeField] private float cellWidth;
    [SerializeField] private float spaceVertical;
    [SerializeField] private float spaceHorizontal;
    
    [Header("Scroll Buttons")] 
    [SerializeField] private GameObject buttonUp;
    [SerializeField] private GameObject buttonDown;
    
    private GameObject[,] _grid;
    private int childCount = 0;
    private int currentFirstVisibleRow = 0;
    private enum ContentMoveDirection{UP = 0, DOWN = 1}


    // Start is called before the first frame update
    void Start()
    {
        if (maxColumns <= 0)
        {
            throw new Exception("maxColumns is smaller than 1");
        }

        if (visibleRows <= 0)
        {
            throw new Exception("visibleRows is smaller than 1");
        }
    }
    /// <summary>
    /// Hides the current row and shows the next row
    /// </summary>
    public void ShowNextRow()
    {
        int maxCurrentFirstVisibleRow = _grid.GetLength(0) - visibleRows - 1;
        if (currentFirstVisibleRow < maxCurrentFirstVisibleRow)
        {
            SetRowVisibility(currentFirstVisibleRow,false);
            SetRowVisibility(currentFirstVisibleRow + visibleRows,true);
            currentFirstVisibleRow++;
            MoveInventoryContent(ContentMoveDirection.UP);
        }
    }
    /// <summary>
    /// Hides the last visible row and shows the one before the current visible row
    /// </summary>
    public void ShowPreviousRow()
    {
        if (currentFirstVisibleRow > 0)
        {
            SetRowVisibility(currentFirstVisibleRow - 1,true);
            SetRowVisibility(currentFirstVisibleRow + visibleRows - 1,false);
            currentFirstVisibleRow--;
            MoveInventoryContent(ContentMoveDirection.DOWN);
        }
    }
    private void MoveInventoryContent(ContentMoveDirection dir)
    {
        Vector3 offset;
        if (dir == ContentMoveDirection.UP)
        {
            offset = new Vector3(0,cellHeight + spaceVertical,0);
        }
        else
        {
            offset = new Vector3(0,-(cellHeight + spaceVertical),0); 
        }

        foreach (var item in _grid)
        {
            if (item)
            {
                item.transform.position += offset;
            }
        }
    }

    private void SetRowVisibility(int row, bool isVisible)
    {
        if (row >= 0)
        {
            for (int i = 0; i < maxColumns; i++)
            {
                if (_grid[row,i])
                {
                    _grid[row,i].SetActive(isVisible);
                }
            }  
        }
    }
    
    

    /// <summary>
    /// Initializes grid and sets positions of items in grid
    /// </summary>
    public void Init()
    {
        InitializeGrid();
        PopulateGrid();
        SetPositionOfItemsInGrid();
        InitializeVisibility();
    }
    
    
    
    /// <summary>
    /// Instantiates a new array with a fitting size
    /// </summary>
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
    /// <summary>
    /// Adds all children with the "InventoryItem"-Tag to the array
    /// </summary>
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
    /// <summary>
    /// Sets the items in the array in the correct position
    /// </summary>
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
                }
            }
            offsetY -= cellHeight + spaceVertical;
        }

    }
    
    /// <summary>
    /// Sets the visibility of the rows in the inventory on startup
    /// </summary>
    private void InitializeVisibility()
    {
        int rows = (int) (childCount / maxColumns) + 1;
        for (int i = 0; i < rows; i++)
        {
            SetRowVisibility(i, i < visibleRows);
        }
    }
}
