using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float ScreenWidthPixel;
    public float ScreenHeightPixel;
    public Vector2 ScreenSizeToWorldPoint;
    public Vector2 GameAreaToWorldPointMin;
    public Vector2 GameAreaToWorldPointMax;
    protected override void Awake()
    {
        base.Awake();
        CalculateScreenSize();
    }
    void CalculateScreenSize()
    {
        ScreenWidthPixel = Screen.width;
        ScreenHeightPixel = Screen.height;
        ScreenSizeToWorldPoint = Camera.main.ScreenToWorldPoint(new Vector2(ScreenWidthPixel, ScreenHeightPixel));
    }
}
