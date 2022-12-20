using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class javCollect : MonoBehaviour
{
    public Sprite[] collects;
    public int currentCollect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentCollect = PlayerPrefs.GetInt("GrenadeLaunch");
        GetComponent<SpriteRenderer>().sprite = collects[currentCollect];
    }
}
