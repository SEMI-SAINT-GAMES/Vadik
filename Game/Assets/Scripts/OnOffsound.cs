using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OnOffsound : MonoBehaviour
{
    public bool isOn;
    public Image soundOnOff;
    public Sprite soundOff;
    public Sprite soundOn;


    private bool areOff;
    private bool areOn;

    // Start is called before the first frame update
    void Start()
    {
        if (AudioListener.volume > 0)
        {
            isOn = true;
            soundOnOff.sprite = soundOn;
            

        }
        else
        {
            isOn = false;
            soundOnOff.sprite = soundOff;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundOnOff()
    {
        if (!isOn)
        {
            AudioListener.volume = 1f;
            isOn = true;
            
            soundOnOff.sprite = soundOn;

        }
        else
        {
            AudioListener.volume = 0f;
            isOn = false;
            soundOnOff.sprite = soundOff;
        }
        
    }
}
