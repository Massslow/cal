using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Bomb : Cell
{
    public override void Open()
    {
        isOpen = true;
        background.sprite = bombImage;
        background.color = Color.white;
    }
}
