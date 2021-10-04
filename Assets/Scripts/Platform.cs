using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Platform : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float boundY = -7f; 
    public bool movingPlatformLeft, movingPlatformRight,
        isBreakable, isSpike, isPlatform;

    private Animator animator;
    public Transform bloodParticle;
    public Player player;
    void Start()
    {
        if (isBreakable)
        {
            animator = GetComponent<Animator>();
        }
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

        if (temp.y <= -8f)
        {
            gameObject.SetActive(false);
        }

    }

    void BreakableDeactivate()
    {
      
        Invoke("DeactivateGameObject",0.35f);
    }

    void DeactivateGameObject()
    {
        Sound.instance.IceBreakSound();
        gameObject.SetActive(false);
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene(0);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Score.scoreValue += 100;

        if(collision.tag == "Player")
        {
            
            if (isSpike)
            {
                Destroy(Instantiate(bloodParticle, collision.transform.position , Quaternion.identity),3f);

                collision.transform.position = new Vector2(1000f,1000f);
                Score.scoreValue = 0;
                Sound.instance.GameOverSound();
                  
                StartCoroutine(Wait());
               

            }
        }
    }
      

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
          

            if (isBreakable)
            {  Score.scoreValue += 50;
                Sound.instance.LandSound();
                animator.Play("Break");
            }
            if (isPlatform)
            {
                Sound.instance.LandSound();
            }
        }
    }

     void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           
            if (movingPlatformLeft)
            {
                collision.gameObject.GetComponent<Player>().PlatformMove(-1f);
            }
            if (movingPlatformRight)
            {
                collision.gameObject.GetComponent<Player>().PlatformMove(1f);
            }
        }
    }
   

}
