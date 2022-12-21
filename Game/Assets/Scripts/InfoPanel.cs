using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    public GameObject infoPanel;
    public Text bigText;
    public Text nameWeapon;
    public Image foto;
    private string currentWeaponStr;
    private string currentGrenadeStr;
    private string currentTankStr;
    
    [TextArea(3, 10)]
    public string[] bigTextsWeapon;
    public string[] namesWeapon;
    public Sprite[] weaponSprites;
    [TextArea(3, 10)]
    public string[] bigTextsGrenade;
    public string[] namesGrenade;
    public Sprite[] grenadeSprites;
    [TextArea(3, 10)]
    public string[] bigTextsTank;
    public string[] namesTank;
    public Sprite[] tankSprites;







    // Start is called before the first frame update
    void Start()
    {
        currentWeaponStr = PlayerPrefs.GetString("CurrentWeaponStr");
        currentGrenadeStr = PlayerPrefs.GetString("GrenadeLaunchStr");
        currentTankStr = PlayerPrefs.GetString("CurrentTankStr");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ButClickWeapon(int cur)
    {
        if (currentWeaponStr.Contains(cur.ToString()) && cur < weaponSprites.Length)
        {
            bigText.text = bigTextsWeapon[cur];
            nameWeapon.text = namesWeapon[cur];
            foto.sprite = weaponSprites[cur];
            infoPanel.SetActive(true);
        }
        else
        {
            bigText.text = "Це поки шо секретик. Скоро дізнаєшся!";
            nameWeapon.text = "Не скажемо";
            foto.sprite = GetComponent<CharacterSettings>().SecretWeapon;
            infoPanel.SetActive(true);
        }
    }
    public void ButClickGrenade(int cur)
    {
        if (currentGrenadeStr.Contains(cur.ToString()) && cur < grenadeSprites.Length)
        {
            bigText.text = bigTextsGrenade[cur];
            nameWeapon.text = namesGrenade[cur];
            foto.sprite = grenadeSprites[cur];
            infoPanel.SetActive(true);
        }
        else
        {
            bigText.text = "Це поки шо секретик. Скоро дізнаєшся!";
            nameWeapon.text = "Не скажемо";
            foto.sprite = GetComponent<CharacterSettings>().secretGrenade;
            infoPanel.SetActive(true);
        }
    }
    public void ButClickTank(int cur)
    {
        if (currentTankStr.Contains(cur.ToString()) && cur < tankSprites.Length)
        {
            bigText.text = bigTextsTank[cur];
            nameWeapon.text = namesTank[cur];
            foto.sprite = tankSprites[cur];
            infoPanel.SetActive(true);
        }
        else
        {
            bigText.text = "Це поки шо секретик. Скоро дізнаєшся!";
            nameWeapon.text = "Не скажемо";
            foto.sprite = GetComponent<CharacterSettings>().secretTank;
            infoPanel.SetActive(true);
        }
    }
    
    public void ClosePanel()
    {
        infoPanel.SetActive(false);
    }

}
