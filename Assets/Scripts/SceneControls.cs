// Handle keyboard input scene controls.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControls : MonoBehaviour
{
    public Animator transistion;
    public float transistionTime = 1f;

    void Update() {
        if(Input.GetKeyDown(KeyCode.R)) LoadNewLevel();
        if(Input.GetKeyDown(KeyCode.Q)) Application.Quit();
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
