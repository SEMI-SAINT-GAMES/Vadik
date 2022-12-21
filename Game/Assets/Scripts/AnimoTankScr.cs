using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimoTankScr : MonoBehaviour
{
    public Sprite[] tankSprite;
    private int currentTank;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTank = PlayerPrefs.GetInt("CurrentTank");
        GetComponent<SpriteRenderer>().sprite = tankSprite[currentTank];
    }
}
