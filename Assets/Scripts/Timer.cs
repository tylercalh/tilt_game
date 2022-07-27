// Show and update the game timer.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timer;
    public static float timerVal;
    
    void Start() {
        timerVal = 0;
    }

    void Update() {
        timerVal += Time.deltaTime;
        timer.text = "Current time " + timerVal.ToString();
    }
}
