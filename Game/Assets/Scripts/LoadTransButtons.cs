using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTransButtons : MonoBehaviour
{
    public GameObject[] buttons; 
    // Start is called before the first frame update
    void Start()
    {
       
        if (PlayerPrefs.GetInt("GameStart") == 0)
        {
            foreach (GameObject but in buttons)
            {
                PlayerPrefs.SetFloat(but.name + "TransformX", but.transform.position.x);
                PlayerPrefs.SetFloat(but.name + "TransformY", but.transform.position.y);
                PlayerPrefs.SetFloat(but.name + "Scale", but.transform.localScale.x);
            }
            PlayerPrefs.SetInt("GameStart", 1);

        }
        else
        {
            LoadTrans();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadTrans()
    {
        
        
        foreach (GameObject but in buttons)
        {
            float posX = PlayerPrefs.GetFloat(but.name + "TransformX");
            float posY = PlayerPrefs.GetFloat(but.name + "TransformY");
            float scale = PlayerPrefs.GetFloat(but.name + "Scale");
            but.transform.position = new Vector3(posX, posY, but.transform.position.z);
            but.transform.localScale = new Vector3(scale, scale, scale);
           
           
           
        }
    }
}
