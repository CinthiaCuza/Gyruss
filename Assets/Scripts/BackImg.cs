using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackImg : MonoBehaviour
{
    public bool isAspectRatio;

    private float scaleFactorX;
    private float scaleFactorY;

    private void Start()
    {
        FitBackground();
    }

    private void Update()
    {
        if(scaleFactorX != scaleFactorY) FitBackground();
    }

    void FitBackground()
    {
        var _topRightCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        var _worldSpaceWidth = _topRightCorner.x * 2;
        var _worldSpaceHeight = _topRightCorner.y * 2;

        var _spriteSize = GetComponent<SpriteRenderer>().bounds.size;

        scaleFactorX = _worldSpaceWidth / _spriteSize.x;
        scaleFactorY = _worldSpaceHeight / _spriteSize.y;

        if (isAspectRatio)
        {
            if (scaleFactorX > scaleFactorY) scaleFactorY = scaleFactorX;
            else scaleFactorX = scaleFactorY;
        }

        transform.localScale = new Vector3(scaleFactorX, -scaleFactorY, 1);
    }
}
