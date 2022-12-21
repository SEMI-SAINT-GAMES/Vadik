using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathManager : MonoBehaviour
{
    public GameObject[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject el in buttons)
        {
            el.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonOff()
    {
        foreach(GameObject el in buttons)
        {
            el.SetActive(false);
        }
    }
    public void ButtonOn()
    {
        foreach (GameObject el in buttons)
        {
            el.SetActive(true);
        }
    }

}
