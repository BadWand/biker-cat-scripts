using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class catMove : MonoBehaviour
{
    GameObject playerObj;
    public Transform point1, point2;
    public float moveSpeed = 0.1f;

    public bool pressedLeft, pressedRight;
    //player Object controller
    catScript cat;
    //animation stuff
    Animator anim;
    Animator catimator;

    //dust particles
    public GameObject dust;
    public GameObject dustsOnImpact;
    GameObject[] bikeComponents;
    public GameObject invisibleGround;

    //camera
    Camera cam;
    Animator camAnim;
    int crashAnimationPlayed = 0;
    int x = 0;
    //audio objects
    public GameObject[] audios;
    public GameObject thud;
    public GameObject brake;
    // Start is called before the first frame update
    void Start()
    {
        audios[0].SetActive(true); // bike sound
        anim = GetComponent<Animator>();
        playerObj = GameObject.FindGameObjectWithTag("Player");
        cat = GameObject.FindObjectOfType<catScript>();
        catimator = cat.gameObject.GetComponent<Animator>();
        bikeComponents = GameObject.FindGameObjectsWithTag("BikeComponent");
        cam = GameObject.FindObjectOfType<Camera>();
        camAnim = cam.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKeyDown("left")) {pressedLeft = true; pressedRight = false;}
    if(Input.GetKeyDown("right")){pressedRight = true; pressedLeft = false;}
    GoToPoint1();
    GoToPoint2(); 
    Jump();

    if (obstacleBehaviour.crashed)
    {
        CrashBike();
    }
    }

    void GoToPoint1()
    {
        if (pressedLeft)
        {
            //print("left");
        float step =  moveSpeed * Time.unscaledDeltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, point1.position, step);
        if (transform.position == point1.position)
            pressedLeft = false;

        }
    }

    void GoToPoint2()
    {
        if (pressedRight)
        {
            //print("right");
        float step =  moveSpeed * Time.unscaledDeltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, point2.position, step);
        if (transform.position == point2.position)
            pressedRight = false;
        }
    }

    public bool MidAir()
    {
        if (transform.position.z <= 0){
            return false;}
        else
            return true;
    }



    void Jump()
    {
        if (Input.GetKey("up") && !MidAir())
        {
            //jump
            anim.SetTrigger("Jumps");
            audios[0].SetActive(false);
            catimator.SetTrigger("bikeJumped");
            camAnim.SetTrigger("bikeJumps");
            dust.SetActive(false);
            audios[1].SetActive(true);
            print("jumps");

        }
    }

    void EndJump()
    {
        audios[0].SetActive(true);
     anim.ResetTrigger("Jumps"); 
    catimator.ResetTrigger("bikeJumped");
    anim.SetTrigger("fall");
    camAnim.ResetTrigger("bikeJumps");
    camAnim.SetTrigger("bikeFalls");
    dust.SetActive(true);
    audios[1].SetActive(false);


    //Instantiate impact dust particles && crash sound
    Instantiate(dustsOnImpact, new Vector3(this.transform.position.x,0f,
    this.transform.position.z), Quaternion.identity);

    }

   
    void CrashBike()
    {
        foreach(GameObject comp in bikeComponents)
        {
            BoxCollider boxCol = comp.GetComponent<BoxCollider>();
            Rigidbody rigby = comp.GetComponent<Rigidbody>();
            if (boxCol == null)
                comp.AddComponent<BoxCollider>();
            if (rigby == null)
                comp.AddComponent<Rigidbody>();
        }
        //disable dust particles && move controls
        try{
        GameObject dust = GameObject.Find("Dust");
        dust.SetActive(false);
        catMove kitty = this.GetComponent<catMove>();
        kitty.enabled = !kitty.enabled;
        }
        catch (NullReferenceException e){ Debug.Log("-");}
        invisibleGround.SetActive(true);
        if (crashAnimationPlayed== 0)
            camAnim.SetTrigger("bikeCrash");
            crashAnimationPlayed = 1;
            Oof();

    }

    void Oof()
    {
        
        if (x == 0){
        Instantiate(thud, this.transform.position, Quaternion.identity);
        x++;
        }
    }

    public void FallSound()
    {
    Instantiate(brake, this.transform.position, Quaternion.identity);

    }



    

    
}
