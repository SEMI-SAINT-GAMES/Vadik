using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSettings : MonoBehaviour
{
    public GameObject weapon;
    public GameObject grenade;
    private int currentWeapon;
    public int currentGrenade;
    public string currentGrenadeStr;
    public int currentTank;
    public string currentTankStr;
    private bool isGrenade;
    public string currentWeaponStr;
    public GameObject[] characterGrenadeArms;
    public GameObject[] characterWeaponArms;
    public Image[] enables;
    public Image[] grenadeEnables;
    public Image[] tankEnables;
    public Sprite[] weaponSprite;
    public Sprite[] grenadeSprite;
    public Sprite SecretWeapon;
    public Sprite secretGrenade;
    public Sprite secretTank;
    public Button[] weaponsButton;
    public Button[] grenadeButton;
    public Button[] tankButton;
    public GameObject weaponView;
    public GameObject grenadeView;
    public GameObject tankView;
    public GameObject wearingView;
    public GameObject[] views;
    public int curView;
    public Text coinCount;
    private AudioSource click;
    public AudioSource[] sounds;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("CurrentWeaponStr", "0/1/2/3/");
        PlayerPrefs.SetString("GrenadeLaunchStr", "0/1/2/3/");
        PlayerPrefs.SetString("CurrentTankStr", "0/1/2/3/");
        currentWeapon = PlayerPrefs.GetInt("CurrentWeapon");
        currentWeaponStr = PlayerPrefs.GetString("CurrentWeaponStr");
       
        //PlayerPrefs.SetInt("CurrentWeapon1", 2);
        PlayerPrefs.SetInt("CurrentTank1", 2);
        PlayerPrefs.SetInt("GrenadeLaunch1", 2);
        isGrenade = false;
        currentGrenade = PlayerPrefs.GetInt("GrenadeLaunch");
        currentGrenadeStr = PlayerPrefs.GetString("GrenadeLaunchStr");
        currentTankStr = PlayerPrefs.GetString("CurrentTankStr");
        Debug.Log(currentWeaponStr);
        click = GetComponent<AudioSource>();
        Asign();
    }

    // Update is called once per frame
    void Update()
    {
        
       
        coinCount.text = PlayerPrefs.GetInt("CoinsCount").ToString();

    }
    public void Asign()
    {
        for (int i = 0; i < enables.Length; i++)
        {
            if (currentWeaponStr.Contains(i.ToString()))

            {
                enables[i].enabled = true;
                weaponsButton[i].interactable = true;
            }
            else
            {
                weaponsButton[i].interactable = false;
                enables[i].sprite = SecretWeapon;
            }
        }
        for (int i = 0; i < grenadeEnables.Length; i++)
        {
            if (currentGrenadeStr.Contains(i.ToString()))
            {
                grenadeEnables[i].enabled = true;
                grenadeButton[i].interactable = true;
            }
            else
            {
                grenadeButton[i].interactable = false;
                grenadeEnables[i].sprite = secretGrenade;
            }
        }
        for (int i = 0; i < tankEnables.Length; i++)
        {
            if (currentTankStr.Contains(i.ToString()))
            {
                tankEnables[i].enabled = true;
                tankButton[i].interactable = true;
            }
            else
            {
                tankButton[i].interactable = false;
                tankEnables[i].sprite = secretTank;
            }
        }

        SelectWeapon();
        
        PlayerPrefs.SetInt("CurrentTank", currentTank);

    }
    public void ViewSelect()
    {
        for (int i = 0; i < views.Length; i++)
        {
            if (i == curView)
            {
                views[i].SetActive(true);
            }
            else
            {
                views[i].SetActive(false);
            }
        }
    }
    public void SelectWeapon ()
    {
        sounds[0].Play();
        if (currentWeapon <= weaponSprite.Length - 1)
        {
            weapon.GetComponentInChildren<SpriteRenderer>().sprite = weaponSprite[currentWeapon];
            PlayerPrefs.SetInt("CurrentWeapon", currentWeapon);
        }

        
        

        
    }
    public void SelectGrenade()
    {
        sounds[1].Play();
        if (currentGrenade <= grenadeSprite.Length - 1)
        {
            grenade.GetComponentInChildren<SpriteRenderer>().sprite = grenadeSprite[currentGrenade];
            PlayerPrefs.SetInt("GrenadeLaunch", currentGrenade);
        }
    }
    public void SelectTank()
    {
        sounds[2].Play();
        if (currentTank <= tankEnables.Length - 1)
        {
            PlayerPrefs.SetInt("CurrentTank", currentTank);
        }
    }
    public void AK47()
    {
        currentWeapon = 0;
        SelectWeapon();
    }
    public void Mosinka()
    {
        currentWeapon = 1;
        SelectWeapon();
    }
    public void MP40()
    {
        currentWeapon = 2;
        SelectWeapon();
    }
    public void M4()
    {
        currentWeapon = 3;
        SelectWeapon();
    }
    public void RPK()
    {
        currentWeapon = 4;
        SelectWeapon();
    }
    public void Vintorez()
    {
        currentWeapon = 5;
        SelectWeapon();
    }
    public void AK74()
    {
        currentWeapon = 6;
        SelectWeapon();
    }
    public void Famas()
    {
        currentWeapon = 7;
        SelectWeapon();
    }
    public void G36()
    {
        currentWeapon = 8;
        SelectWeapon();
    }
    public void RPG()
        {
        currentGrenade = 0;
        SelectGrenade();
        }
public void PzrSrck()

    {
        currentGrenade = 1;
        SelectGrenade();
    }
public void Javelin()
    {
        currentGrenade = 2;
        SelectGrenade();
    }
public void Matador()
    {
        currentGrenade = 3;
        SelectGrenade();
    }
public void Nlaw()
{
        currentGrenade = 4;
        SelectGrenade();
    }
public void M72()
{
        currentGrenade = 5;
        SelectGrenade();
    }
public void PzrFaust()
{
        currentGrenade = 6;
        SelectGrenade();
    }
public void WeaponView()
    {
        /*weaponView.SetActive(true);
        grenadeView.SetActive(false);
        tankView.SetActive(false);
        wearingView.SetActive(false);*/
        ClickSound();
        curView = 0;
        ViewSelect();
        foreach(GameObject w in characterWeaponArms)
        {
            w.SetActive(true);
        }
        foreach (GameObject g in characterGrenadeArms)
        {
            g.SetActive(false);
        }
        
    }

    public void GrenadeView()
    {
        
        ClickSound();
        curView = 1;
        ViewSelect();
        foreach (GameObject w in characterWeaponArms)
        {
            w.SetActive(false);
        }
        foreach (GameObject g in characterGrenadeArms)
        {
            g.SetActive(true);
        }

    }
    public void TankView()
    {
        
        ClickSound();
        curView = 2;
        ViewSelect();

    }
    public void HelmetView()
    {
        
        ClickSound();
        curView = 3;
        ViewSelect();
    }
    public void TorsoView()
    {
        ClickSound();
        curView = 4;
        ViewSelect();
    }
    public void PansView()
    {
        ClickSound();
        curView = 5;
        ViewSelect();
    }
    public void T64()
    {
        currentTank = 0;
        SelectTank();
    }
    public void Mark1()
    {
        currentTank = 1;
        SelectTank();
    }
public void Tigr()
    {
        
        currentTank = 2;
        SelectTank();
    }
public void Leopard()
    {
        currentTank = 3;
        SelectTank();
    }
    public void Abrams()
    {
        currentTank = 4;
        SelectTank();
    }
    public void T14()
    {
        currentTank = 5;
        SelectTank();
    }
    void ClickSound()
    {
        click.Play();
    }
}
