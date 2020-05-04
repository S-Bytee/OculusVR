using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchTo3D : MonoBehaviour
{


    public Animator animator;
    void OnTriggerEnter(Collider other)
    {

        FadeToLevel(1);

    }
    
    private int levelToLoad;
 

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = 1;
        animator.SetTrigger("Fade_out");

    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
