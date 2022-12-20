using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button level2b;
    public Button level3b;
    public int levelComplete;
    LoadingScreen loadingScreen;
    public Button continueGame;
    public string[] sceneNames;

    // Start is called before the first frame update
    void Start()
    {
        loadingScreen = GameObject.FindGameObjectWithTag("LoadingScreen").GetComponent<LoadingScreen>();
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        /*level2b.interactable = false;
        level3b.interactable = false;

        switch (levelComplete)
        {
            case 1:
                level2b.interactable = true;
                break;
            case 2:
                level2b.interactable = true;
                level3b.interactable = true;
                break;

        }*/
        if (levelComplete > 0)
        {
            continueGame.interactable = true;
        }
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
        loadingScreen.Load("Level1");
    }
    public void CharacterSettings()
    {
        loadingScreen.Load("CharacterSettings");
    }
    public void SelectCity()
    {
        loadingScreen.Load("Map");
    }
    public void ButtonSettings()
    {
        loadingScreen.Load("ButtonSettings");
    }
}
