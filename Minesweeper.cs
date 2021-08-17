using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        InitializeBombs();
        InitializeNeighboursBombsCount();
    }

    private void InitializeGrid()
    {
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                grid[i, j] = Instantiate(cellPrefab,transform);
    }

        
    private void InitializeBombs()
    {
        int count = 0;
        while (count < bombs)
        {
            int position = Random.Range(0, size * size);
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
                grid[i,j].neighBombs = GetNeighboursBombsCount(i,j);
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
