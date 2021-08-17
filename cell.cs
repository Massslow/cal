using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cell : MonoBehaviour
{
    public bool isBomb {get; private set;}
    
    public int neighBombs;

    public void SetBomb()
    {
        IsBomb == true;
    }

    public bool isOpen {get; private set;}
    public void Open()
    {
        background.enabled = false;

        if (isBomb)
            bombCountText.text = "*";
        else
            bombCountText.text = neighBombs > 0 ? neighBombs.ToString() : "";

    }

    public void OnCellPressed()
    {
        minesweeper.OnCellPressed(this);
    }

    [SerializeField] private Minesweeper minesweeper;

    [Space]
    [SerializeField] private Image background;
    [SerializeField] private Text bombCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
