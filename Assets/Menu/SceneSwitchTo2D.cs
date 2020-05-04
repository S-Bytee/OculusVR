using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchTo2D : MonoBehaviour
{

    public Animator animator;
    void OnTriggerEnter(Collider other)
    {

        FadeToLevel(3);

    }

    private int levelToLoad;


    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = 3;
        animator.SetTrigger("Fade_out");

    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
