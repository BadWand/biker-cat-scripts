using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameSpeed : MonoBehaviour
{

    

    public enum state {Decreasing, Increasing, minWait, maxWait};
    public state _state;
    public float waitBetween;
    public float increaseSpeed = 0.2f;
    public float count = 0;
    //counters
    public float minCount, maxCount = 0;
    void Awake()
    {
        Time.timeScale = 1;
        _state = state.minWait;

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    state changeState (state current)
    {/*
        if (current == state.minWait)
        {
           // float count = 0;
            count += Time.unscaledDeltaTime;
            print(count);
            if (count >= WaitBeforeDecrease)
                current = state.Increasing;
        }
        else if (current == state.Increasing)
        {
            Time.timeScale += increaseSpeed * Time.unscaledDeltaTime;
            if (Time.timeScale >= 2f)
            {
                Time.timeScale = 2f;
                current = state.maxWait;
            }
        }

        else if (current == state.maxWait)
        {
            count = 0;
            count += Time.unscaledDeltaTime;
            if (count >= (WaitBeforeDecrease * 2))
            {
                
                Time.timeScale -= increaseSpeed * Time.unscaledDeltaTime;
                if (Time.timeScale <= 1f)
                {
                    Time.timeScale = 1f;
                    current = state.Decreasing;
                }
            }
        }

        else if (current == state.Decreasing)
        {
           Time.timeScale -= increaseSpeed * Time.unscaledDeltaTime;
            if (Time.timeScale <= 1f)
            {
                Time.timeScale = 1f;
                current = state.minWait;
            }
        }
       */
       
        return current;
    }
    
    ///////////
    void ChangeTime()
    {
     if (_state == state.minWait)
     {
         minCount += Time.unscaledDeltaTime;
         if (minCount >= waitBetween)
         {
             _state = state.Increasing;
         }
     }

     else if (_state == state.Increasing)
     {
        if (Time.timeScale <= 3f)
            Time.timeScale += increaseSpeed * Time.unscaledDeltaTime;
        else
            _state = state.maxWait;
     }
     else if (_state == state.maxWait)
     {

         maxCount += Time.unscaledDeltaTime;
         if (maxCount >= (waitBetween * 8))
         {
             _state = state.Decreasing;
         }
     }
     else if (_state == state.Decreasing)
     {
        if (Time.timeScale > 1f)
            Time.timeScale -= increaseSpeed * Time.unscaledDeltaTime;
        else
            _state = state.minWait;
     }
    }
    ////////////
    void ResetTimers()
    {
        //if this is not the state, make the counter 0
        if (_state != state.minWait)
            minCount = 0;
        else if (_state != state.maxWait)
            maxCount = 0;

     
    }
    //////////////
    // Update is called once per frame
    void Update()
    {
       // IncreaseGameSpeed();
   
        ChangeTime();
        ResetTimers();
    }



   


}
