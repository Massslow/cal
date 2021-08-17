using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Minesweeper : MonoBehaviour
{
    public void OnCellPressed(Cell cell)
    {
        if (cell.isBomb)
        {
            Debug.LogError("Game Over");
            return;
        }
        cell.Open();
    }
    [SerializeField] private Cell cellPrefab;
    [Space]
    [SerializeField] private int size = 10;
    [SerializeField] private int bombs = 10;
    private Cell[,] grid;

    private void Awake()
    {
        InitializeGrid();
        InitializedBombs();
        InitializeNeighboursBombsCount();
    }

    private void InitializeGrid()
    {
        for(int i = 0, i < size; i++)
            for(int j = 0, j < size; j++)
                grid[i, j] = Instantiate(cellPrefab,transform);
    }

        
    private void InitializedBombs()
    {
        int count = 0;
        while (count < bombs)
        {
            int position = Random.Randge(0,size * size);
            int x = position / size;
            int y = position % size;

            if (grid[x,y].isBomb == false)
            {
                grid[x,y].SetBomb();
                count++;
            }
        }


    }

    private void InitializeNeighboursBombsCount()
    {
        for(int i = 0, i < size; i++)
            for(int j = 0, j < size; j++)
            grid[i,j].neighBpmbs = GetNeighboursBombsCount(i,j);
    }

    private int GetNeighboursBombsCount(int x, int y)
    {
        int count = 0;
        for (int i = -1; i <= 1; i++)
            for (int j = -1; j <= 1; j++)
            {
                if (x + i < 0 || x + i >= size || y + j < 0 || y + j >= size)
                    continue;
                if (grid[x+i,y+j].isBomb)
                    count++;
            }
        return count;
    }
}
        
