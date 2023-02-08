using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //for player movement we need to access the rigidbody component of that player
    //so we created a variable of type Rigidbody2D
    public Rigidbody2D playerrigidbody;
    public float speed;                          //speed of player moovement
   

    void Start()
    {
        
       

    }

    
    void Update()
    {                                                                                //for inouts you can also use
                                                                                     // But I observed delay wtih this GetAxis option
        if (Input.GetKey(KeyCode.RightArrow))                                       // Input.GetAxis("Horizontal") > 0;
        {
            playerrigidbody.velocity = new Vector2(speed, 0f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))                                  //Input.GetAxis("Horizontal") < 0;
        {
            playerrigidbody.velocity = new Vector2(- speed, 0f);
        }
        else if (Input.GetKey(KeyCode.UpArrow))                                   //Input.GetAxis("Vetrtical") > 0;
        {
            playerrigidbody.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))                                 //Input.GetAxis("Vetrtical") < 0;
        {
            playerrigidbody.velocity = new Vector2(0f, - speed);
        }

        else
        {
            playerrigidbody.velocity = new Vector2(0f, 0f);
            
        }
    }
}
