﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPointer2D : MonoBehaviour
{


    private static PhysicsPointer2D _instance;
    public static PhysicsPointer2D Instance { get { return _instance; } }
    [SerializeField] protected float maxLength = 9.0f;
    [SerializeField] protected float minLength = 2.0f;
    public float defaultLength = 4.0f;

    Color c1 = Color.white;
    Color c2 = Color.red;
    Color c3 = Color.green;
    public RaycastHit hit;

    public Ray ray;
    public bool onCollison;

    private TrailRenderer trailRenderer;
    private LineRenderer lineRenderer = null;
    // Start is called before the first frame update
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

        lineRenderer = GetComponent<LineRenderer>();
        trailRenderer = GameObject.Find("TrailLine").GetComponent<TrailRenderer>();
        if (ColorIndicator.Instance == null)
        {
            lineRenderer.startColor = c1;
        }
        else
        {
            lineRenderer.startColor = ColorIndicator.Instance.color.ToColor();
        }


    }




    // Update is called once per frame
    void Update()
    {
        UpdateLength();
        changeLaserLength();
        updateColor();
        if (!onCollison)
            trailFollow();
    }



    private void UpdateLength()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, CalculateEnd());
    }



    public Vector3 CalculateEnd()
    {
        RaycastHit hit = CreateForwardRaycast();
        Vector3 endposition = DefaultEnd(defaultLength);
        if (hit.collider)
        {
            endposition = hit.point;
            this.hit = hit;
            lineRenderer.endColor = c3;
            onCollison = true;
        }
        else
        {
            lineRenderer.endColor = c2;
            onCollison = false;
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

    public void updateColor()
    {
        if (ColorIndicator.Instance == null)
        {
            this.c1 = Color.white;
            lineRenderer.startColor = this.c1;

        }
        else
        {

            this.c1 = ColorIndicator.Instance.color.ToColor();
            lineRenderer.startColor = this.c1;

        }


    }

    public void trailFollow()
    {

        if (trailRenderer != null)
        {
            trailRenderer.transform.position = CalculateEnd();
        }
    }

}
