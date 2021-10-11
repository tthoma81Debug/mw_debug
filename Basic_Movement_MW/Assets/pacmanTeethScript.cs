using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pacmanTeethScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool canMelee = false;
    GameObject theThingWeHit;
    Animator theAnimator;
    void Start()
    {
        theAnimator = GameObject.Find("pacman").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            theAnimator.SetBool("hitMelee", true);
            if(canMelee == true)
            {
                //hit ghost
                ghostScriptTTH theScript = theThingWeHit.GetComponent<ghostScriptTTH>();

                theScript.takeDamage();
            }
           
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("ghost"))
        {
            canMelee = true;
            theThingWeHit = collision.gameObject;

        }
        else
        {
            //Debug.Log("Collision Detected");



        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canMelee = false;
    }
}
