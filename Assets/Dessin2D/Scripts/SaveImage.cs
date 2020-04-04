using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveImage : MonoBehaviour
{

    public RenderTexture RTexture;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F3))
        {
            Debug.Log("Screen captured.");
            ScreenCapture.CaptureScreenshot("CAPTURE ECRAN/Screenshot_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png");
        }
        if (Input.GetKeyUp(KeyCode.F3))
        {
            Debug.Log("Screen captured.");
            ScreenCapture.CaptureScreenshot("CAPTURE ECRAN/Screenshot_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png");
        }

    }
    public void save()
    {
        StartCoroutine(CoSave());

    }

    private IEnumerator CoSave()
    {

        yield return new WaitForEndOfFrame();
        Debug.Log(Application.dataPath + "/savedImage.png");

        RenderTexture.active = RTexture;
        var texture2D = new Texture2D(RTexture.width, RTexture.height);
        texture2D.ReadPixels(new Rect(0, 0, RTexture.width, RTexture.height), 0, 0);
        var data = texture2D.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/savedImage.png", data);

    }
}
