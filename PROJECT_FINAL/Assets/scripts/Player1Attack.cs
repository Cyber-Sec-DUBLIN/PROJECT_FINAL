using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Player1Attack : MonoBehaviour
{


    public int canmove = 1;  
    
    public GameObject player1;
    public GameObject player2;
    public GameObject fireObj;
    public GameObject fireMir; //this version of the fireball is spawned if the player is on the other side of the enemy. preventing the fireball from spawning behind the player and shooting them 
    public GameObject punchObj;

     public AudioClip punchSound;
    public AudioClip FireballSound;
    private AudioSource AudioPlay;

    public Vector3 facingPOS = new Vector3(3,0,0);
    
       
    // Start is called before the first frame update
    void Start()
    {
    AudioPlay = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    async void Update()
    {

           if (player1.transform.position.x > player2.transform.position.x) {
            facingPOS = new Vector3(-3,0,0);
        }
        else {
            facingPOS = new Vector3(3,0,0);
        }
        //If player 1 is behind the enemy. set the facing position (which determines where to spawn the attack objects) to negative. And if not then keep it the same

                if (Input.GetKeyDown(KeyCode.E))  { 
            if (canmove == 1 && player1.transform.position.x < player2.transform.position.x ) {
            canmove = 0; 
        Instantiate(fireObj, transform.position + facingPOS, fireObj.transform.rotation); 
        AudioPlay.PlayOneShot(FireballSound, 0.9F);
        await Task.Delay(1000); //after seconds
        canmove = 1; 
        }
                else if (canmove == 1 && player1.transform.position.x > player2.transform.position.x ) {
            canmove = 0; 
        Instantiate(fireMir, transform.position + facingPOS, fireObj.transform.rotation); 
        AudioPlay.PlayOneShot(FireballSound, 0.9F);
        await Task.Delay(1000); //after seconds
        canmove = 1; 
        }
        } 

        if (Input.GetKeyDown(KeyCode.R))  { 
            if (canmove == 1) {
            canmove = 0; 
        Instantiate(punchObj, transform.position + facingPOS, punchObj.transform.rotation); 
        AudioPlay.PlayOneShot(punchSound, 1F);
        await Task.Delay(400); //after seconds
        canmove = 1; 
        }
        } 
            /*
        This is a bit complicated so let me summarize
        1 If the player has pressed(key)
        2 (for the fireball attack) If so is canMove on and where are they positioned relative to the enemy
        3 disable movement, summon fireball/punch, wait 1000/400 milliseconds. enable movement
        4 depending on if the player is behind or infront of the enemy. shoot a different fireball
        */


        
    }
}
