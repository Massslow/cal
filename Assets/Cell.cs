using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public int x;
    public int y;
    [HideInInspector]
    public int neighBombs;

    

    public bool isOpen { get; protected set; }
    public virtual void Open()
    {
        isOpen = true;
        background.enabled = false;
        bombCountText.text = neighBombs > 0 ? neighBombs.ToString() : "";

    }

    public void OnCellPressed()
    {
        minesweeper.OnCellPressed(this);
    }

    [Space]
    [SerializeField] public Sprite bombImage;
    [SerializeField] protected Image background;
    [SerializeField] protected TextMeshProUGUI bombCountText;

    protected Minesweeper minesweeper;
    protected void Awake()
    {
        minesweeper = FindObjectOfType<Minesweeper>();
        bombCountText.text = "";
    }
}
