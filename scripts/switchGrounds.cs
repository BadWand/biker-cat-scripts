using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchGrounds : MonoBehaviour
{
    Transform ground;
    public float newGroundPos, minPos, moveSpeed;
    gameSpeed speedMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        ground = this.gameObject.transform;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GroundSorting();
        Move();
    }
    
    void GroundSorting()
    {
        if (ground.position.z <= minPos)
        {
            ground.position = new Vector3(ground.position.x, ground.position.y, newGroundPos);
        }


        if (obstacleBehaviour.crashed)
        {
            moveSpeed = 0;
        }
    }

    void Move()
    {
       
            if (!obstacleBehaviour.crashed) //if player hasn't crashed
            {
                //if timescale is less than 2.105
                if (Time.timeScale < 2.105f)
                {
                //movespeed is time.timescale divided by 20
                moveSpeed = Time.timeScale / 20;
                }
                else if (Time.timeScale >= 2.105f)
                {
                    moveSpeed = 0.105f;
                }
                //^but if time.timescale is bigger than 2.105
                //moveSpeed = 0.105f;

        transform.position -= new Vector3(0, 0, 1) * moveSpeed;
            }
    }
}
