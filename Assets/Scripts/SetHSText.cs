// Show current fastest completion time.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetHSText : MonoBehaviour
{
    public TMP_Text highScoreText;

    void Start() {
        float hscore = PlayerPrefs.GetFloat("Highscore", 0);
        highScoreText.text = "Fastest time " + hscore.ToString();
    }
}
