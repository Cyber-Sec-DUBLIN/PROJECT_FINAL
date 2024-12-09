using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class melee : MonoBehaviour
{

    public GameObject MELEE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    async void Update()
    {
       await Task.Delay(300); 
        Destroy(MELEE); 
    }
}
