using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostScript : MonoBehaviour
{
    // Start is called before the first frame update
    int ghostHealth = 100;
    Animator thisGhostAnimator;
    void Start()
    {
        thisGhostAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage()
    {
        ghostHealth -= 50;
        Debug.Log("ghost hit. ghost health is " + ghostHealth);
        if(ghostHealth <=0)
        {
            
            thisGhostAnimator.SetBool("isDead", true);
           // Destroy(this.gameObject);

        }
    }
}
