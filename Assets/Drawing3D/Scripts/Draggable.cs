using UnityEngine;

public class Draggable : MonoBehaviour
{
	public bool fixX;
	public bool fixY;
	public Transform thumb;	
	bool dragging;

    PhysicsPointer laserInstance;

    private void Start()
    {
        laserInstance = PhysicsPointer.Instance;

	}

    void FixedUpdate()
	{
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
			var point = laserInstance.DefaultEnd(laserInstance.defaultLength);
			point = GetComponent<Collider>().ClosestPointOnBounds(point);
			SetThumbPosition(point);
			SendMessage("OnDrag", Vector3.one - (thumb.position - GetComponent<Collider>().bounds.min) / GetComponent<Collider>().bounds.size.x);
        
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
