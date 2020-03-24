using UnityEngine;

public class ExampleColorReceiver : MonoBehaviour {
	
    Color color;
    private static ExampleColorReceiver _instance;
    public static ExampleColorReceiver Instance { get { return _instance; } }

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
   public void OnColorChange(HSBColor color) 
	{
        this.color = color.ToColor();
	}

    void OnGUI()
    {
		var r = Camera.main.pixelRect;
		var rect = new Rect(r.center.x + r.height / 6 + 50, r.center.y, 100, 100);
		GUI.Label (rect, "#" + ToHex(color.r) + ToHex(color.g) + ToHex(color.b));	
    }

	string ToHex(float n)
	{
		return ((int)(n * 255)).ToString("X").PadLeft(2, '0');
	}
}
