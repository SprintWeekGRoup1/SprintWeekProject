using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDuper : MonoBehaviour
{
    [SerializeField] GameObject bgImgObj;
    [SerializeField] float numberOfDuplicates;

    private float spriteSizeX;

    void Start()
    {
        spriteSizeX = bgImgObj.GetComponent<SpriteRenderer>().bounds.size.x;
        DupeBackground();
    }

    private void DupeBackground()
    {
        for (int i = 1; i <= numberOfDuplicates; i++)
        {
            GameObject newBackground = Instantiate(bgImgObj, transform);
            float newX = bgImgObj.transform.position.x + i * spriteSizeX;
            newBackground.transform.localPosition = new Vector3(newX, bgImgObj.transform.position.y);

            if (i % 2 != 0)
            {
                Vector3 scale = newBackground.transform.localScale;
                scale.x *= -1;
                newBackground.transform.localScale = scale;
            }
        }


    }
}
