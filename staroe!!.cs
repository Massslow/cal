using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minesweeper : MonoBehaviour
{
    public void OnCellPressed(Cell cell)
    {
        if (cell.isBomb)
        {
            OpenAll();
            Debug.LogError("Game Over");
            return;
        }
        
        if (cell.neighBombs == 0)
        {
            OpenNeighFree(cell);
            return;
        }
        cell.Open();
    }
    [SerializeField] private Cell cellPrefab;
    [Space]
    [SerializeField] private int size = 11;
    [SerializeField] private int bombs = 30;
    private Cell[,] grid;

    private void Awake()
    {
        InitializeGrid();
        InitializeBombs();
        InitializeNeighboursBombsCount();
    }

    private void InitializeGrid()
    {
        grid = new Cell[size,size];
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
            {
                grid[i, j] = Instantiate(cellPrefab,transform);
                grid[i,j].x = i;
                grid[i,j].y = j;
            }
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
        for(int i = 0; i < size; i++)
            for(int j = 0; j < size; j++)
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
    
    private void OpenAll()
    {
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                grid[i, j].Open();
    }

    private void OpenNeighFree(Cell cell)
    {
        List<Cell> shouldVisit = new List<Cell>();
        shouldVisit.Add(cell);

        while(shouldVisit.Count > 0)
        {
            Cell first = shouldVisit[0];
            shouldVisit.RemoveAt(0);
            first.Open();
            if (first.neighBombs > 0)
                continue;

            for(int i = -1; i <= 1; i++)
                for(int j = -1; j <= 1; j++)
                {
                    int x = first.x + i;
                    int y = first.y + j;

                    if (x < 0 || x >= size || y < 0 || y >= size)
                        continue;
                        
                    if (grid[x,y].isBomb == false && grid[x,y].isOpen == false)
                        shouldVisit.Add(grid[x,y]);
                }
        }
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
