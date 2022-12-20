using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKmagazin : MonoBehaviour
{
    public int currentWeapon;
    public Sprite[] currentSprite;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
            sr.sprite = currentSprite[currentWeapon];

        currentWeapon = PlayerPrefs.GetInt("CurrentWeapon");

    }
}
