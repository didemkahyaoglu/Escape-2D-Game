using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialPlatform : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatform;

    public float platformRepeatTimer = 1.8f;
    private float currentPlatformRepeatTimer ;
    private int platformRepeatCount;

    public float minX= -2f , maxX = 2f;

    void Start()
    {
        currentPlatformRepeatTimer = platformRepeatTimer;
    }
    void Update()
    {
        RepeatPlatforms();
    }

    void RepeatPlatforms()
    {
        currentPlatformRepeatTimer += Time.deltaTime;
    
        if(currentPlatformRepeatTimer >= platformRepeatTimer)
        {
            platformRepeatCount++;

            Vector3 temp = transform.position;
            temp.x = Random.Range(minX, maxX);

            GameObject newPlatform = null;

            
            if(platformRepeatCount < 2)
            {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            }
            else if(platformRepeatCount == 2)
            {
                if(Random.Range(0,2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(movingPlatforms[Random.Range(0, movingPlatforms.Length)], temp, Quaternion.identity);
                }
            }
            else if (platformRepeatCount == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);
                }
            }
            else if (platformRepeatCount == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(breakablePlatform, temp, Quaternion.identity);
                }
                platformRepeatCount = 0;
            }
            currentPlatformRepeatTimer = 0f;
        }     
    }
}
