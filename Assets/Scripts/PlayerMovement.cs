using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    //for player movement we need to access the rigidbody component of that player
    //so we created a variable of type Rigidbody2D
    public Rigidbody2D playerrigidbody;
    public float speed; 
    float maxspeed;

    //public GameObject gamewonpanel;
    public GameObject canvas;
    private bool IsGameWon = false;

    public GameObject PauseMenu;
    private bool IsGamePasued = false;

    public UnityEvent myevent;
    private bool Isplayerdead = false;

   

    void Start()
    {
       


    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Game Paused");
            PauseMenu.SetActive(true);
            IsGamePasued = true;
        }

        if(IsGameWon == true)
        {
            return;
        }
           
                                                                                     //for inouts you can also use
        if (Input.GetKey(KeyCode.RightArrow))                                       // Input.GetAxis("Horizontal") > 0;   // But I observed delay wtih this GetAxis option    
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

        else if(collision.tag == "EnemyWall")
        {
            Debug.Log("Level Lost");
            myevent.Invoke();
            Isplayerdead = true;
            RestratGame();
        }
    }

   

   public void RestratGame()
    {
        SceneManager.LoadScene(0);
    }
  
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        IsGamePasued = false;
    }
}
