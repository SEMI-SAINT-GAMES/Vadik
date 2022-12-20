using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitazOrk : EnemyPatrool
{
    public Sprite emptySprite;
    public Sprite defSprite;

    // Start is called before the first frame update
    void Start()
    {
        Asign();
    }

    // Update is called once per frame
    void Update()
    {
        Do();
        if (isShooting == true)
        {
            GetComponent<SpriteRenderer>().sprite = emptySprite;
            Invoke("DefSprite", 0.7f);
        }
    }
    public void DefSprite()
    {
        GetComponent<SpriteRenderer>().sprite = defSprite;
    }
    

}