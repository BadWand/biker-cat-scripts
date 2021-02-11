using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leafRotation : MonoBehaviour
{
    public float rotY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    RotateYAxis();
    }

    void RotateYAxis()
    {
        transform.Rotate(0,rotY*Time.deltaTime,0, Space.World);

    }
}
