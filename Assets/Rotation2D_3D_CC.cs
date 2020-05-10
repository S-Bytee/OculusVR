using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation2D_3D_CC : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        transform.Rotate(new Vector3(0f, -1f, 0f));
    }
}
