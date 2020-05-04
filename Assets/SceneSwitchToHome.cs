using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchToHome : MonoBehaviour
{


    public Animator animator;
    void OnTriggerEnter(Collider other)
    {

        FadeToLevel(6);

    }

    private int levelToLoad;


    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = 6;
        animator.SetTrigger("Fade_out");

    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
