using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicOnOff : MonoBehaviour
{
    private bool isOn;
    private bool isOff;
    public AudioSource music;
    public Image musicOnOff;
    public Sprite musicOn;
    public Sprite musicOff;
    private int onMusic = 1;
    private int ofMusic = 0;
    int currentOnOff;
   
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        currentOnOff = PlayerPrefs.GetInt("IsOnMusic");

        if (currentOnOff == 1) 
        {
            music.volume = 0.3f;
            isOn = true;
            musicOnOff.sprite = musicOn;
            PlayerPrefs.SetInt("IsOnMusic", onMusic);
        }
        else if (currentOnOff == 0)
        {
            music.volume = 0f;
            isOn = false;
            musicOnOff.sprite = musicOff;
            PlayerPrefs.SetInt("IsOnMusic", ofMusic);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnOffMusic()
    {
        if (!isOn)
        {
            music.volume = 1f;
            isOn = true;
            musicOnOff.sprite = musicOn;
            PlayerPrefs.SetInt("IsOnMusic", onMusic);
        }
        else
        {
            music.volume = 0f;
            isOn = false;
            musicOnOff.sprite = musicOff;
            PlayerPrefs.SetInt("IsOnMusic", ofMusic);
        }
    }
}
