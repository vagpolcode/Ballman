using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateControl : MonoBehaviour
{

    
    public GameObject Rotatedcontrol;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotatedcontrol.transform.Rotate ( Vector3.left * ( 20 * Time.deltaTime ) );

        
    }

    


}
