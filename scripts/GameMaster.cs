using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameMaster : MonoBehaviour
{
    public static int leafCount;
    public static int donutCount;
    Text donutCounter;
    Text leafCounter;
    int x = 0;
    //canvas
    GameObject canvas;
    Animator canvasAnimator;

    //enable / disable sound & music
    public Sprite soundOn;
    public Sprite soundOff;
    void Awake()
    {
        leafCount = 0;
        donutCount = 0;
        obstacleBehaviour.crashed = false;
        canvas = GameObject.Find("Canvas");
        canvasAnimator = canvas.GetComponent<Animator>();


    Screen.SetResolution(640, 480, true);

    try {
        donutCounter = GameObject.FindGameObjectWithTag("DonutCounter").GetComponent<Text>();
        leafCounter = GameObject.FindGameObjectWithTag("LeafCounter").GetComponent<Text>();
        x++;
    }
    catch(NullReferenceException  e)
    {
        Debug.Log("no donut/leaf counter!!");
    }
    }
    



    // Update is called once per frame
    void Update()
    {
        Restart();
        Quit();
        UpdateScore();
        GameOverScreen();
    }

    void Restart()
    {
        if(Input.GetKey(KeyCode.R))
        
            SceneManager.LoadScene("SampleScene");
        
    }

    void Quit()
    {
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
    }

    void UpdateScore()
    {
        if (x >= 1)
        {
            donutCounter.text = donutCount.ToString();
            leafCounter.text = leafCount.ToString();
        }
    }

    void GameOverScreen()
    {
        if (obstacleBehaviour.crashed)
            canvasAnimator.SetTrigger("crashed");


    }


    public void MuteOrUnmute()
    {
        try{
        AudioSource music = GameObject.Find("music").GetComponent<AudioSource>();
        Button sound = GameObject.Find("soundButton").GetComponent<Button>();
            music.enabled = !music.enabled;
        if (music.isActiveAndEnabled)
            sound.GetComponent<Image>().sprite = soundOn;
        else if (!music.isActiveAndEnabled)
            sound.GetComponent<Image>().sprite = soundOff;
 
        }
        catch (NullReferenceException e)
        {
            Debug.Log(" is missing from scene. Can't mute / unmute!");
        }
    }
    
}
