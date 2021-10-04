using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialStars : MonoBehaviour
{

    public GameObject starPrefab;
    public float starRepeatTimer = 1.8f;
    private float currentStarRepeatTimer;
    private int starRepeatCount;

    public float minX = -2f, maxX = 2f;
    void Start()
    {
        currentStarRepeatTimer = starRepeatTimer;
    }

    void Update()
    {
        RepeatStars();
    }


    void RepeatStars()
    {
        currentStarRepeatTimer += Time.deltaTime;


        if (currentStarRepeatTimer >= starRepeatTimer)
        {
            starRepeatCount++;

            Vector3 temp = transform.position;
            temp.x = Random.Range(minX, maxX);

            GameObject newStar = null;
  
                if (Random.Range(0, 2) > 0)
                {
                    newStar = Instantiate(starPrefab, temp, Quaternion.identity);
                }
            
            
            currentStarRepeatTimer = 0f;

        }
    }

}
