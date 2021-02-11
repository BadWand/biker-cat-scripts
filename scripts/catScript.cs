using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catScript : MonoBehaviour
{
    Animator animator;
    public Transform pos;
    catMove bikeReference;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        bikeReference = GameObject.FindObjectOfType<catMove>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = pos.position;
        
    }
}
