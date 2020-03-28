using UnityEngine;

public class Draggable : MonoBehaviour
{
	public bool fixX;
	public bool fixY;
	public Transform thumb;	
	public bool dragging;

    PhysicsPointer laserInstance;
	private static Draggable _instance;

	public static Draggable Instance { get { return _instance; } }

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			//Destroy(this.gameObject);
		}
		else
		{
			_instance = this;
		}
	}
	private void Start()
    {
        laserInstance = PhysicsPointer.Instance;
		

	}

    void FixedUpdate()
	{

		Debug.Log(dragging);

		if (Input.GetMouseButtonDown(0)) {
			dragging = false;

            if (GetComponent<Collider>().Raycast(laserInstance.ray, out laserInstance.hit, laserInstance.defaultLength)) {
				dragging = true;


			}

		}
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;

        }
        if (dragging && Input.GetMouseButton(0)) {
			var point = laserInstance.hit.point;
			point = GetComponent<Collider>().ClosestPointOnBounds(point);
			SetThumbPosition(point);
			SendMessage("OnDrag", Vector3.one - (thumb.position - GetComponent<Collider>().bounds.min) / GetComponent<Collider>().bounds.size.x);
			//GameObject.Find("BackgroundColor").GetComponent<Renderer>().material.color = ColorIndicator.Instance.color.ToColor();

		}


	}

	void SetDragPoint(Vector3 point)
	{
		point = (Vector3.one - point) * GetComponent<Collider>().bounds.size.x + GetComponent<Collider>().bounds.min;
		SetThumbPosition(point);
	}

	void SetThumbPosition(Vector3 point)
	{
		thumb.position = new Vector3(fixX ? thumb.position.x : point.x, fixY ? thumb.position.y : point.y, thumb.position.z);
	}
}
