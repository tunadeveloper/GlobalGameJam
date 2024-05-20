using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;
    private Vector3 movement;
    private bool isMoving;
    private Rigidbody2D rb;

    private int anahtarCount = 3;

    private bool timerActive = false;
    private float timerDuration = 120f; 
    private float timer;

    void Start()
    {
        animator = GetComponent<Animator>();
        isMoving = false;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;


    }

    void Update()
    {
    
        float moveX = Input.GetAxis("Horizontal"); 
        float moveY = Input.GetAxis("Vertical");   

      
        movement = new Vector3(moveX, moveY, 0f);

     
        if (movement != Vector3.zero && !isMoving)
        {
            animator.SetTrigger("run");
            isMoving = true;
        }
        else if (movement == Vector3.zero && isMoving)
        {
            animator.SetTrigger("Isrun");
            isMoving = false;
        }
    }

    void FixedUpdate()
    {
       
        transform.position += movement * moveSpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("collider"))
        {
            Destroy(gameObject); 
        }

 
           
            if (collision.gameObject.CompareTag("anahtar") || collision.gameObject.CompareTag("anahtar2") || collision.gameObject.CompareTag("anahtar3"))
            {
                Destroy(collision.gameObject);
                anahtarCount--;

             
                if (anahtarCount == 0)
                {
                    GameObject sonObj = GameObject.FindWithTag("son");
                    if (sonObj != null)
                    {
                        sonObj.GetComponent<Collider2D>().enabled = true;
                    }
                }
            }

          
            if (collision.gameObject.CompareTag("son") && anahtarCount == 0)
            {
                SceneManager.LoadScene(3); 
            }

        if (collision.gameObject.CompareTag("tuzak"))
        {
            SceneManager.LoadScene(2);
        }
    }

    }





