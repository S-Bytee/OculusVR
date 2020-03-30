using UnityEngine;

public class ColorSaturationBrightnessPicker : MonoBehaviour {

    public Material backgroundMaterial;

    private static ColorSaturationBrightnessPicker _instance;
    public static  ColorSaturationBrightnessPicker Instance { get { return _instance; } }

    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

    }

    public void SetColor(HSBColor color)
	{

        backgroundMaterial.SetColor("_Color", new HSBColor(color.h, 1, 1).ToColor());
        SendMessage("SetDragPoint", new Vector3(color.s, color.b, 0));

    }
    
    void OnDrag(Vector3 point)
    {

        //transform.parent.BroadcastMessage("SetSaturationBrightness", new Vector2(point.x, point.y));
        GameObject.Find("ColorIndicator").GetComponent<ColorIndicator>().SetSaturationBrightness(new Vector2(point.x, point.y));
             

        //Idhaa ken aamal selection aala objet donc badaalou couleur 
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("object"))
        {

            if (go.GetComponentInChildren<OnSelectObject>().isClicked )
            {

                go.transform.GetChild(0).GetComponent<Renderer>().material.color = ColorIndicator.Instance.color.ToColor();

            }
        }



    }

    void SetHue(float hue)
    {

		backgroundMaterial.SetColor("_Color", new HSBColor(hue, 1, 1).ToColor());

    }	
}
