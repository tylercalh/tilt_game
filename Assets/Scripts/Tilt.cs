// Handle keyboard inputs to control the gameboard tilt.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour
{
    //float horizontalSpeed = 3.5f;
    //float verticalSpeed = 3.5f;
    //float h;
    //float v;
    Rigidbody rb;
 
    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();  
    }

    void Update(){
        
    }

    void FixedUpdate() {
        /* if(Input.GetMouseButton(0)) {
            // Get the mouse delta. This is not in the range -1...1
            h = horizontalSpeed * Input.GetAxis("Mouse X");
            v = verticalSpeed * Input.GetAxis("Mouse Y");
   
            // regular mouse control:
            //rb.transform.Rotate(v, 0, -1 * h);

        } else {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime * 5.0f);
            rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.identity, Time.fixedDeltaTime * 5.0f);
        } */

        float x = 0;
        float z = 0;

        if(Input.GetKey(KeyCode.W)) {
            x = 50;
                    
        }
        if(Input.GetKey(KeyCode.S)) {
            x = -50;
              
        }
        if(Input.GetKey(KeyCode.D)) {
            z = -50;
            
        }
        if(Input.GetKey(KeyCode.A)) {
            z = 50;
             
        }

        rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.Euler(x, 0, z), Time.fixedDeltaTime * 2.0f);
    }
}
