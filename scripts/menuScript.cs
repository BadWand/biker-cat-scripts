using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuScript : MonoBehaviour
{

    public GameObject buttons;
    public GameObject howToPlay;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ClickPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ClickHowToPlay()
    {
        buttons.SetActive(false);
        howToPlay.SetActive(true);
        panel.SetActive(true);
    }

    public void ClickBack()
    {
        howToPlay.SetActive(false);
        buttons.SetActive(true);
        panel.SetActive(false);
    }
}
