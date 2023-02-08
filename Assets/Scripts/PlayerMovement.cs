using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //for player movement we need to access the rigidbody component of that player
    //so we created a variable of type Rigidbody2D
    public Rigidbody2D playerrigidbody;
    public float speed; 
    float maxspeed;

    //public GameObject gamewonpanel;
    public GameObject canvas;
    public GameObject PauseMenu;
    private bool IsGameWon;
    private bool IsGamePaused;
   

    void Start()
    {

        


    }

    
    void Update()
    {
        if(IsGameWon == true)
        {
            return;
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            PauseMenu.SetActive(true);
           
        }
        


        // But I observed delay wtih this GetAxis option                             //for inouts you can also use
        if (Input.GetKey(KeyCode.RightArrow))                                       // Input.GetAxis("Horizontal") > 0;
        {
            playerrigidbody.velocity = new Vector2(speed * Time.deltaTime, 0f);
            
        }
        else if (Input.GetKey(KeyCode.LeftArrow))                                  //Input.GetAxis("Horizontal") < 0;
        {
            playerrigidbody.velocity = new Vector2(- speed * Time.deltaTime, 0f); 
        }
        else if (Input.GetKey(KeyCode.UpArrow))                                   //Input.GetAxis("Vetrtical") > 0;
        {
            playerrigidbody.velocity = new Vector2(0f, speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))                                 //Input.GetAxis("Vetrtical") < 0;
        {
            playerrigidbody.velocity = new Vector2(0f , - speed * Time.deltaTime);
        }

        else if(Input.GetKeyDown(KeyCode.Space))
        {
            playerrigidbody.velocity = new Vector2(0f, 0f);
            
        }
        if (maxspeed < 130)
        {
            speed++;   
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Prize")
        {
            Debug.Log("Level Complete");
            canvas.SetActive(true);
            IsGameWon = true;
        }
    }

  
}
