using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostScriptTTH : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;
    Animator ghostAnimator;

    void Start()
    {
        ghostAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage()
    {
        health = health - 50;
        Debug.Log("Ghost hit! Health is now" + health);

        if(health <= 0)
        {
            ghostAnimator.SetBool("ghostDeath", true);
            //Destroy(this.gameObject);
        }
    }
}
