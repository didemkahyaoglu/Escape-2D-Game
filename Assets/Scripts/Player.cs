using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myBody;
    public float moveSpeed= 2f ;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        
    }

     void Move()
    {
        Vector2 temp = transform.position; ;
        temp.y -= moveSpeed * Time.deltaTime;
        transform.position = temp;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            float jumpVelocity = 11f;
            myBody.velocity = Vector2.up * jumpVelocity;
        }


        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            myBody.velocity = new Vector2(moveSpeed,myBody.velocity.y);
        }


        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
        }

    }
    public void PlatformMove (float x)
    {
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            Sound.instance.StarSound();
            Score.scoreValue += 200;
            Destroy(collision.gameObject);
        }
    }
}
