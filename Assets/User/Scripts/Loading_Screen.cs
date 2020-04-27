using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading_Screen : MonoBehaviour
{
    public Animator transition ;
    public float transitionTime = 4f;
    
        void Update()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(PlayerPrefs.GetString("scene"));
    }
}
