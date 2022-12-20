using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController1 : MonoBehaviour
{
    public static LevelController1 instance= null;
    public int sceneIndex;
    int levelComplete;
    LoadingScreen loadingScreen;
    public string[] sceneNames;
    Control control;
    
    
    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.FindGameObjectWithTag("Player").GetComponent<Control>();
        loadingScreen = GameObject.FindGameObjectWithTag("LoadingScreen").GetComponent<LoadingScreen>();
        if (instance == null)
        {
            instance = this;
        }
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SceneIndex", sceneIndex);
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        Debug.Log("scene index =" + sceneIndex);

        
    }
    public void isEndGame()
    {
        if (sceneIndex == 3)
        {
            loadingScreen.Load("Map");
        }
        else 
        {

            if (levelComplete < sceneIndex)

                PlayerPrefs.SetInt("LevelComplete", sceneIndex);

            loadingScreen.Load("Map");


        }
        
    }


   void NextLevel()
    {
        loadingScreen.Load(sceneNames[sceneIndex + 1]);
        //SceneManager.LoadScene(sceneIndex + 1);
    }
    public void LoadMainMenu()
    {
       loadingScreen.Load("MainMenu");
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        loadingScreen.Load(sceneNames[sceneIndex]);
        Time.timeScale = 1f;
    }
    public void Continue()
    {
        loadingScreen.Load(sceneNames[levelComplete]);
        Time.timeScale = 1f;
    }
    public void Settings()
    {
        loadingScreen.Load("ButtonSettings");
        Time.timeScale = 1f;
    }
    public void CharacterSettings()
    {
        loadingScreen.Load("CharacterSettings");
        Time.timeScale = 1f;
    }
    public void SniperLoad()
    {
        Time.timeScale = 1f;
        loadingScreen.Load("Sniper");
        
    }
    public void BossBattleLoad()
    {
        loadingScreen.Load("BossBattle");
        Time.timeScale = 1f;
        
    }
    public void StugnaLoad()
    {
        loadingScreen.Load("Stugna");
        Time.timeScale = 1f;
    }
    public void BossReaload()
    {
        loadingScreen.Load("BossBattle");
    }
}
