using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    Text killCount;
    public static int kill;
    
    // Start is called before the first frame update
    void Start()
    {
        killCount = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Token", kill);
       
        //killCount.text = PlayerPrefs.GetInt("Token").ToString();
    }
}
