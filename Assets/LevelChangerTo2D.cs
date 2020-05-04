using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerTo2D : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }
    private int levelToLoad;
    // Update is called once per frame


    public void FadeToLevel(int levelIndex)
    {

        animator.SetTrigger("Fade_out");

    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(3);
    }
}
