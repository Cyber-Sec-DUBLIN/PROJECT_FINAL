using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class player1con : MonoBehaviour
{
    // Start is called before the first frame update

    public Player1Attack script;
    //This lets us access the variables from the Attack script
    
    public int HEALTHPOINTS = 250;
    public TextMeshProUGUI health_text_1; //textmesh variable
     public TextMeshProUGUI winntext;

    public float jumpforce1 = 150; 
    public float gravitymod1 = 2;
    public bool isGround = true;
    public int speed = 20;
    public float AD;
    
    public GameObject player; //the gameobject for the player

    private Rigidbody playerRb; //rigidbody 

    public AudioClip jumpSound;
    public AudioClip hitSound;
    
    private AudioSource AudioPlay;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();   
        Physics.gravity *=gravitymod1;
        AudioPlay = GetComponent<AudioSource>();
    }

    // Update is called once per frame
   void Update() //the task.delay function only works if the method is async
    {
         health_text_1.text = " " + HEALTHPOINTS;

    AD = Input.GetAxis("Horizontal"); //telling it hoirzontal puts movement keys on a and d 
   
    player.transform.Translate(Vector3.right * speed * Time.deltaTime * AD * script.canmove); //this single line controls movement. Wonderful isn't it

    if (Input.GetKeyDown(KeyCode.LeftShift) && isGround) {
            AudioPlay.PlayOneShot(jumpSound, 0.5F);
            playerRb.AddForce(Vector3.up * jumpforce1, ForceMode.Impulse);
            isGround = false;  
            
            
        }
       if (isGround == false) { 
        speed = 10;
       }
       else {
        speed = 20;
       }
       //In real life it is incredibly difficult to change the direction whilst in the air. This carries over to video game as well


         if (HEALTHPOINTS <= 0) {
                
                
                Destroy(player);
                
            }
            //Destroy player if health is less than 0


        }

        private void OnCollisionEnter(Collision collision) { //resets isground when on ground
        isGround = true;
        
        if (collision.gameObject.CompareTag("PUNCH")) { 
            AudioPlay.PlayOneShot(hitSound,0.3f);
            HEALTHPOINTS = HEALTHPOINTS - 30;
        }

         if (collision.gameObject.CompareTag("FIREBALL")) { 
            AudioPlay.PlayOneShot(hitSound,0.3f);
            HEALTHPOINTS = HEALTHPOINTS - 6;
        }
        //The fireball object is made up of 4 objects. This became a problem as it caused the fireball to deal 4 times its regular damage
        //To solve this. I just dropped the damage low so that the multiple objects making up fireball would buff the damage up to the correct number


        //I will admit collision stuff was a bit of a hassle. Mostly because I thought that tag was another word for the objects name but turns out you gotta create tags and then apply them
        //to the object for this stuff to work
        }

        async void OnDestroy() {
        
        winntext.text = "PLAYER 2 WINS ";
        health_text_1.text = "";
        await Task.Delay(4000);
        SceneManager.LoadScene(0);
        
    }   
}

