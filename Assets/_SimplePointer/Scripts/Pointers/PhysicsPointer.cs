﻿using UnityEngine;

public class PhysicsPointer : MonoBehaviour
{


    private static PhysicsPointer _instance;

    public static PhysicsPointer Instance { get { return _instance; } }


    [SerializeField] protected float maxLength = 9.0f;
    [SerializeField] protected float minLength = 2.0f;
    public float defaultLength = 4.0f;

    Color c1 = Color.white;
    Color c2 = Color.red;
    Color c3 = Color.green;
    public RaycastHit hit;

    public Ray ray;

    private LineRenderer lineRenderer = null;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startColor = c1;



        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Update()
    {
        UpdateLength();
        changeLaserLength();
    }

    private void UpdateLength()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, CalculateEnd());
    }



    protected Vector3 CalculateEnd()
    {
        RaycastHit hit = CreateForwardRaycast();
        Vector3 endposition = DefaultEnd(defaultLength);
        if (hit.collider)
        {
            endposition = hit.point;
            this.hit = hit;
            lineRenderer.endColor = c3;
        }
        else
        {
            lineRenderer.endColor = c2;
        }

        return endposition;
    }


    private RaycastHit CreateForwardRaycast()
    {
        RaycastHit hit;
        ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, defaultLength);


        return hit;
    }

    public Vector3 DefaultEnd(float length)
    {

        return transform.position + (transform.forward * length);

    }


    private void changeLaserLength()
    {

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (defaultLength >= maxLength)
            {
                defaultLength = maxLength;
            }
            else
            {
                defaultLength += 1f;
            }
        }


        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (defaultLength <= minLength)
            {
                defaultLength = minLength;
            }
            else
            {
                defaultLength -= 1f;
            }
        }
    }
}