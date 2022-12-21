using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PansViewSettings : MonoBehaviour
{
    public Button[] buttons;
    public string butName;
    public Sprite[] enabledBut;
    public Sprite[] notEnabledBut;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("OpenPans", "/");

        ButActive();
    }

    // Update is called once per frame
    void Update()
    {
        butName = PlayerPrefs.GetString("OpenPans");
    }
    public void ButActive()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (butName.Contains(buttons[i].name))
            {
                buttons[i].image.sprite = enabledBut[i];
            }
            else
            {
                buttons[i].image.sprite = notEnabledBut[i];
            }
        }
    }
}
