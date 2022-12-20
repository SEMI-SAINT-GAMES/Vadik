using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadingScreen : MonoBehaviour
{
    
    public GameObject loadingScreen;
    public Image loadingImage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Load(string level)
    {
        loadingScreen.SetActive(true);
        //SceneManager.LoadScene(loadLevel);
        StartCoroutine(LoadAsync(level));
    }
    IEnumerator LoadAsync(string level)
    {
       
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(level);


        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress < .92f)
            {
                loadingImage.fillAmount += 0.7f * Time.deltaTime;
            }
            else 
            { 
                loadingImage.fillAmount = asyncLoad.progress;
            }
                
            

            yield return null;
        }
        
        






    }
}
