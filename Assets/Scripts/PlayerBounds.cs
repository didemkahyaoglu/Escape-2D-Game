﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public float minX = -2.6f, maxX = 2.6f, minY = -5.6f, maxY = 5.6f;
    private bool outOfBounds;
   
    void Update()
    {
        CheckBounds();
    }

    void CheckBounds()
    {
        Vector2 temp = transform.position;

        if (temp.x > maxX)
            temp.x = maxX;

        if (temp.x < minX)
            temp.x = minX;

        transform.position = temp;

        if (temp.y <= minY)
        {
            if (!outOfBounds)
            {
                outOfBounds = true;
                  Sound.instance.DeathSound();
                 LoadScene.instance.RestartGame();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Flame")
        {
            transform.position = new Vector2(1000f, 1000f);
            Sound.instance.DeathSound();
            LoadScene.instance.RestartGame();
        }

    }
    }


