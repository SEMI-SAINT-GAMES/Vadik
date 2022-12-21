using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ConfilmPanelPans : MonoBehaviour
{
    public int currentConfilm;
    public Image image;
    public Text text;
    public Sprite[] images;
    public string[] texts;
    public int curCoins;
    public string opens;
    public int[] price;
    public string[] currentName;
    public AudioSource buySound;
    public AudioSource cancelSound;
    public AudioSource clickSound;
    // Start is called before the first frame update
    void Start()
    {

        opens = PlayerPrefs.GetString("OpenPans");
        
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = images[currentConfilm];
        text.text += " " + texts[currentConfilm];
        curCoins = PlayerPrefs.GetInt("CoinsCount");
    }
    public void Yes()
    {
        if (curCoins >= price[currentConfilm])
        {
            buySound.Play();
            PlayerPrefs.SetInt("CoinsCount", curCoins -= price[currentConfilm]);

            PlayerPrefs.SetString("OpenPans", opens += "/" + currentName[currentConfilm]);
            Invoke("ButActive", 0.3f);

            gameObject.SetActive(false);
            


        }
        else
        {
            cancelSound.Play();
            
            GetComponent<Animator>().SetTrigger("No");
        }
    }
    public void No()
    {
        clickSound.Play();
        gameObject.SetActive(false);
    }
    public void ButActive()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PansViewSettings>().ButActive();
        //player.GetComponent<WearCharacterSettings>().CurWear1();

    }

}
