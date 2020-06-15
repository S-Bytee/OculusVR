using Shapes2D;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TestPreview : MonoBehaviour
{
    public byte[] bytes;
    Texture2D texture;
    public GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        bytes = new byte[20000];

     

    }

    // Update is called once per frame
    void Update()
    {
        texture = AssetPreview.GetAssetPreview(go);
        Sprite tempSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 0);
        GetComponent<Image>().sprite = tempSprite;

    }
}
