using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 
//imports you may notice three that stick out
//Threading.Tasks is used for delays. I know one of the units has a way of delaying things but I couldn't get it to work so I choose a different way of delaying scripts
//SceneManagement lets me control what scene is currently being shown
//TMPro lets us access TextMesh/UI elements

public class player2con : MonoBehaviour
{

    public Player2Attack script;

    //This lets us access the variables from the Attack script. In this case the canmove variable

    public int HEALTHPOINTS = 250; //heatlth points
    public TextMeshProUGUI health_text_2; //textmesh variable
    public TextMeshProUGUI winntext; //changes text on the UI to indicate player2 has won

    public float jumpforce2 = 150; 
    public float gravitymod2 = 2;
    public bool isGround = true;
    public int speed = 20;
    public float JL = 0; //movement
   
    public AudioClip jumpSound;
    public AudioClip hitSound;
    
    private AudioSource AudioPlay;
    

    public GameObject player; //the gameobject for the player
    
    private Rigidbody playerRb; //rigidbody 

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();   
        Physics.gravity *=gravitymod2;
        AudioPlay = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        health_text_2.text = " " + HEALTHPOINTS;
        //updating HUD to show current health
           
     
    
    if(Input.GetKeyDown(KeyCode.J)) { //if going left
       JL = -1; 
    }
    else if (Input.GetKeyDown(KeyCode.L)) { //if going right
        JL = 1;
    }
    else if(Input.GetKeyUp(KeyCode.J) | Input.GetKeyUp(KeyCode.L)) { //if not pressing buttons
        JL=0;
    }
    else {
        ;
    }
    //the code for adding player movement only checks for WASD. That is why I had to resort to this

   
    player.transform.Translate(Vector3.right * speed * Time.deltaTime * JL * script.canmove); //this single line controls movement. Wonderful isn't it

    if (Input.GetKeyDown(KeyCode.Space) && isGround) {
            playerRb.AddForce(Vector3.up * jumpforce2, ForceMode.Impulse);
            isGround = false;  
            AudioPlay.PlayOneShot(jumpSound, 0.5F);
            
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
        
         if (collision.gameObject.CompareTag("PUNCH")) { //This part kinda annoyed me since I thought CompareTag mean the objects name. 
         AudioPlay.PlayOneShot(hitSound,0.1f);
            HEALTHPOINTS = HEALTHPOINTS - 30;
        }

         if (collision.gameObject.CompareTag("FIREBALL")) {
         AudioPlay.PlayOneShot(hitSound,0.1f);
            HEALTHPOINTS = HEALTHPOINTS - 6; 
        }
        //The fireball object is made up of 4 objects. This became a problem as it caused the fireball to deal 4 times its regular damage
        //To solve this. I just dropped the damage low so that the multiple objects making up fireball would buff the damage up to the correct number


        //I will admit collision stuff was a bit of a hassle. Mostly because I thought that tag was another word for the objects name but turns out you gotta create tags and then apply them
        //to the object for this stuff to work
  }

 async void OnDestroy() {
        
        winntext.text = "PLAYER 1 WINS";
        health_text_2.text = "";
        
        await Task.Delay(4000);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
  


}


