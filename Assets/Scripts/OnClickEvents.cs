using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnClickEvents : MonoBehaviour
{
    public TextMeshProUGUI soundsText;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.mute)
        {
            soundsText.text = "/";
        }
        else
        {
            soundsText.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToggleMute()
    {
        if(GameManager.mute)
        {
            GameManager.mute = false;
            soundsText.text = "";
        }
        else
        {
            GameManager.mute = true;
            soundsText.text = "/";
        }
    }
}