// This script instantiates the checkerboard within the map.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour {

    public GameObject checkw;
    public GameObject checkb;
    public GameObject parent;
    
    void Start() {
        for(int i = 0; i < 11; i ++) {
            for(int j = 0; j < 11; j++) {  
                bool check = (i % 2 == 0) ? (j % 2 == 0) : (j % 2 == 1);
                if(check) Instantiate(checkw, new Vector3(i - 5f, 0.51f, j - 5f), Quaternion.identity, parent.transform);
                else Instantiate(checkb, new Vector3(i - 5f, 0.51f, j - 5f), Quaternion.identity, parent.transform);
            }
        } 
    }
}
