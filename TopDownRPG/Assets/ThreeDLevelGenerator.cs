﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDLevelGenerator : MonoBehaviour
{
    public Texture2D map;

    public ColorToPrefab[] colorMappings;

    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
    }
    void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
       Color pixelColor= map.GetPixel(x, y);

        if (pixelColor.a == 0)
        {
            Debug.Log("blank");
            return;

        }

        Debug.Log(pixelColor);

        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if(colorMapping.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x, 0, y);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
                return;
            }
        }


    }
 
}
