using UnityEngine;

public class ColorIndicator : MonoBehaviour {

	public HSBColor color;
    private static ColorIndicator _instance;
    public static ColorIndicator Instance { get { return _instance; } }



    void Start() {

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        color = HSBColor.FromColor(GetComponent<Renderer>().material.GetColor("_Color"));
        //GameObject.Find("ColorPicker").transform.BroadcastMessage("SetColor", color);
        if (ColorSaturationBrightnessPicker.Instance != null)
            ColorSaturationBrightnessPicker.Instance.SetColor(color);
    }

    void ApplyColor ()
	{


		GetComponent<Renderer>().material.SetColor("_Color", color.ToColor());
      
        if(ColorSaturationBrightnessPicker.Instance != null) 
            ColorSaturationBrightnessPicker.Instance.SetColor(color);

        //transform.parent.BroadcastMessage("OnColorChange", color, SendMessageOptions.DontRequireReceiver);
    }

    public void SetHue(float hue)
	{

		color.h = hue;
		ApplyColor();


    }	

	public void SetSaturationBrightness(Vector2 sb) {

        color.s = sb.x;
		color.b = sb.y;
		ApplyColor();

    }

   

}
