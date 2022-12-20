using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowitzerPanel : MonoBehaviour
{
    public Image weapon;
    public Sprite[] weapSprite;
    private string[] texts = new string[5];
    private string[] weaponNames = new string[5];
    public Text text;
    public Text nameText;
    public int currentHow;
    // Start is called before the first frame update
    void Start()
    {
        texts[0] = "Pion";
        texts[1] = "M777";
        texts[2] = "Himars";
        texts[3] = "ISKANDER";
        texts[4] = "HimarsAtacms";
        weaponNames[0] = "СВД";
        weaponNames[1] = "G43";
        weaponNames[2] = "Barret M107";
        weaponNames[3] = "AW50";
        weaponNames[4] = "ATACMS";
    }

    // Update is called once per frame
    void Update()
    {
        currentHow = PlayerPrefs.GetInt("CurrentHowitzer");
        weapon.sprite = weapSprite[currentHow];
        text.text = texts[currentHow];
        nameText.text = weaponNames[currentHow];
    }
}
