using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleBehaviour : MonoBehaviour
{
    public float moveSpeed;

     public GameObject player;
    public bool test;
    public float maxDist = 2f;
    catMove cat;
    public bool collectible;
    public static bool crashed;
    public bool leafChild;

    //pickup / crash sound
    public GameObject objAudio;
    //float groundValue = 0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cat = GameObject.FindObjectOfType<catMove>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Move();
        Hurt();
        
        if (transform.position.z <= -10f)
        {
            DestroySelf();
        }

        if (crashed)
        {
            moveSpeed = 0;
        }
        
    }

    void Move()
    {
        //always lose transform Z at rate moveSpeed
        if (!crashed)
        {
            if (!leafChild)
                moveSpeed = Time.timeScale / 20;
        transform.position -= new Vector3(0, 0, 1) * moveSpeed;
        }
    }

    void Hurt()
    {
       /* float dist = transform.position.z - player.transform.position.z;
        float posX = transform.position.x - player.transform.position.x;
        float catOnGround = player.transform.position.y;
        if (dist <= maxDist && dist > -1f)
        {
           if (posX > -.5f && posX < .5f && catOnGround == groundValue)
             if (test)
              print("Close!");
        }*/


        if (Vector3.Distance(transform.position, player.transform.position) < maxDist)
        {
            if (collectible)
                {
                Instantiate(objAudio, this.transform.position, Quaternion.identity);
                if (this.gameObject.CompareTag("Leaf"))
                {
                    GameMaster.leafCount += 1;
                    print("Leaf count: " + GameMaster.leafCount);
                } else
                {
                    GameMaster.donutCount += 1;
                    print("Donut count: " + GameMaster.donutCount);

                }
                Destroy(this.gameObject);
                
                }
            else 
                {
                   // print("You'reeee hit!");
                    crashed = true;
                }
        }
    }

    void DestroySelf()
    {
        
    Destroy(this.gameObject);
        
    }

    
}
