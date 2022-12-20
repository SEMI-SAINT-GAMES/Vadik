using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GajetPanel : MonoBehaviour
{
    public Image weapon;
    public Sprite[] weapSprite;
    private string[] texts = new string[4];
    private string[] weaponNames = new string[4];
    public Text text;
    public Text nameText;
    public int currentSniper;
    // Start is called before the first frame update
    void Start()
    {
        texts[0] = "svd";
        texts[1] = "g43";
        texts[2] = "barretm107";
        texts[3] = "aw50";
        weaponNames[0] = "СВД";
        weaponNames[1] = "G43";
        weaponNames[2] = "Barret M107";
        weaponNames[3] = "AW50";
    }

    // Update is called once per frame
    void Update()
    {
        currentSniper = PlayerPrefs.GetInt("CurrentSniper");
        weapon.sprite = weapSprite[currentSniper];
        text.text = texts[currentSniper];
        nameText.text = weaponNames[currentSniper];
    }
}
