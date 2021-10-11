using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pacmanMain : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject theCharacter;
    Rigidbody2D physicsEngine;
    Vector2 theForce;
    Vector2 rightForce;
    Vector2 leftForce;
    bool isJumping = false;
    int pacmanHealth = 100;
    bool canHit = false;
    ghostScript theOtherScript;
    GameObject theOtherObject;
    Animator theAnimation;
    GameObject theSword;
    void Start()
    {
        theCharacter = GameObject.Find("pacman");
        physicsEngine = theCharacter.GetComponent<Rigidbody2D>();
        theForce = new Vector2(0, 8);
        rightForce = new Vector2(10, 0);
        leftForce = new Vector2(-10, 0);

        //physicsEngine.AddForce(theForce, ForceMode2D.Impulse);

        theOtherObject = GameObject.Find("pacmanGhost_0");
        theOtherScript = theOtherObject.GetComponent<ghostScript>();

        Debug.Log("Yaaay. it is working");
        theSword = GameObject.Find("sword_0");
        theAnimation = theSword.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isJumping == false)
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                physicsEngine.AddForce(theForce, ForceMode2D.Impulse);
                isJumping = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                physicsEngine.AddForce(rightForce);
               // physicsEngine.velocity = new Vector2(10, 0);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                physicsEngine.AddForce(leftForce);
            }
        }
        else
        {
            //do nothing. user already jumped
        }

        //melee logic
        if (Input.GetKeyDown(KeyCode.F)) //melee key
        {
            if(canHit == true)
            {
                theOtherScript.takeDamage();
            }
            else
            {
                Debug.Log("Cannot attack. No enemy in range");
            }

            theAnimation.SetBool("meleePressed", true);
            

        }


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

      isJumping = false;
      

      if(collision.gameObject.name == "pacmanGhost_0")
        {

           // theOtherScript.takeDamage();
            //  Debug.Log("Ouch. ghost sting");
            // pacmanHealth = pacmanHealth - 10;

            if (pacmanHealth <= 0)
            {
                //bye bye pacman
                //Destroy(this.gameObject);
          //      Debug.Log("Pacman is defeated. Game Over.");

            }
            else
            {
          //      Debug.Log("pacman's health is now " + pacmanHealth);
            }
            
        }


       
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //runs when pacman trigger collides
        

        if (collision.gameObject.name == "pacmanGhost_0")
        {
            Debug.Log("Trigger is Working!");
            canHit = true;
            
            

        }
        

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        //runs when we leave the trigger area
        if (collision.gameObject.name == "pacmanGhost_0")
        {
            canHit = false;
        }
    }

}
