using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public int levelComplete;
    LoadingScreen loadingScreen;
    public Button continueGame;
    public string[] sceneNames;
    public AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        loadingScreen = GameObject.FindGameObjectWithTag("LoadingScreen").GetComponent<LoadingScreen>();
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        
        if (levelComplete > 0)
        {
            continueGame.interactable = true;
        }
        click = GetComponent<AudioSource>();
    }
    /*public void LoadTo(int level)
    {
        SceneManager.LoadScene(level);
    }*/
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Continue()
    {
        Sound();
        if (levelComplete < sceneNames.Length - 1)
        {
            loadingScreen.Load(sceneNames[levelComplete + 1]);
        }
        else
        {
            loadingScreen.Load(sceneNames[levelComplete]);
        }
    }
    public void NewGame()
    {
        Sound();
        loadingScreen.Load("Level1");
    }
    public void CharacterSettings()
    {
        Sound();
        loadingScreen.Load("CharacterSettings");
    }
    public void SelectCity()
    {
        Sound();
        loadingScreen.Load("Map");
    }
    public void ButtonSettings()
    {
        Sound();
        loadingScreen.Load("ButtonSettings");
    }
    public void About()
    {
        Sound();
    }
    void Sound()
    {
        click.Play();
    }
}
