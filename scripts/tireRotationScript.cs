using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tireRotationScript : MonoBehaviour
{
    public float rotateZ = 10f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RotateZAxis();
    }

    void RotateZAxis()
    {
        transform.Rotate(rotateZ* Time.deltaTime,0,0, Space.World);

    }
}
