using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbound : MonoBehaviour
{

    public GameObject player;
    public float bound1 = 14; //boundary for left side of the screen
    public float bound2 = -14; //boundary for right

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if (transform.position.x > bound1) {
        transform.position = new Vector3(bound1, transform.position.y, transform.position.z);
     }   

     if (transform.position.x < bound2) {
        transform.position = new Vector3(bound2, transform.position.y, transform.position.z);
     }   
    }
}
