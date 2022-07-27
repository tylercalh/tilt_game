// Handle level loading and 'win' sound effect.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GoalReached : MonoBehaviour
{
    public Animator transistion;
    public float transistionTime = 0.5f;
    public AudioClip winclip;
    
    void Start() {
        GetComponent<AudioSource>().clip = winclip;
    }
    
    private void OnTriggerEnter() {
        float hscore = PlayerPrefs.GetFloat("Highscore", 0);
        float cscore = Timer.timerVal;

        if(hscore == 0 || cscore < hscore) {
            PlayerPrefs.SetFloat("Highscore", cscore);
        }

        GetComponent<AudioSource>().Play();
        transistion = GameObject.Find("Canvas").GetComponent<Animator>();
        LoadNewLevel();
    }

    public void LoadNewLevel() {
        StartCoroutine(Load());
    }

    IEnumerator Load() {
        transistion.SetTrigger("Start");
        yield return new WaitForSeconds(transistionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
