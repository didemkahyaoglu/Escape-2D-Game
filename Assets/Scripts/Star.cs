using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float moveSpeed = 2f;

    void Update()
    {
        starMove();
        
    }
    void starMove()
    {
        Vector2 temp = transform.position; ;
        temp.y -= moveSpeed * Time.deltaTime;
        transform.position = temp;


        if (temp.y <= -8f)
        {    
            gameObject.SetActive(false);
        }

    }
}
