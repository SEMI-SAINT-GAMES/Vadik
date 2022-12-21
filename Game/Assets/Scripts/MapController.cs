using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    public int levelComplete;
    public Button[] levels;
    LoadingScreen loadingScreen;
    private AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("LevelComplete", 1);
        loadingScreen = GameObject.FindGameObjectWithTag("LoadingScreen").GetComponent<LoadingScreen>();
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        Debug.Log(levelComplete);
        LevelAsign();
        click = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LevelAsign()
    {
        for (int i = 0; i< levels.Length; i++)
        {
            if (i < levelComplete)
            {
                levels[i].interactable = true;
                
            }
            else
            {
                levels[i].interactable = false;
                
            }
        }
    }
    public void Level1()
    {
        Sound();
       loadingScreen.Load("Level1");
    }
    public void Level2()
    {
        Sound();
        loadingScreen.Load("Level2");
    }
    public void Level3()
    {
        Sound();
        loadingScreen.Load("Level3");
    }
    public void LoadMainMenu()
    {
        Sound();
        loadingScreen.Load("MainMenu");
    }
    void Sound()
    {
        click.Play();
    }
}
