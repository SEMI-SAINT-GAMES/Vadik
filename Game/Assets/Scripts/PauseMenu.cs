using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    int sceneIndex1;
    LoadingScreen loadingScreen;
    public string[] sceneNames;
    

    // Start is called before the first frame update
    void Start()
    {
        sceneIndex1 = SceneManager.GetActiveScene().buildIndex;
        loadingScreen = GameObject.FindGameObjectWithTag("LoadingScreen").GetComponent<LoadingScreen>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*public void PauseDown()
    {
        if (GameIsPaused)
        {
            Resume();

        }
        else
        {
            Pause();
        }
    }*/

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Menu()
    {
        loadingScreen.Load(sceneNames[0]);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        loadingScreen.Load(sceneNames[sceneIndex1]);
        Time.timeScale = 1f;
    }

     
}
