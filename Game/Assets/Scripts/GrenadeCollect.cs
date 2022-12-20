using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeCollect : MonoBehaviour
{
    public Sprite[] weapons;
    private string[] texts = new string[7];
    private string[] weaponNames = new string[7];
    public Text text;
    public Text weaponName;
    public int currentWeapon;
    public Image weapon;

    // Start is called before the first frame update
    void Start()
    {
        texts[0] = "Слава Укранїні брате! Полковник наказав залишити тобі тут файний сюрпрайз для спалення ординців, і ми це виконали. Але боєприпаси, нажаль, терміново довелося віддати на потребу нашого партизанського взіоду, а без пострілів для РПГ ти наврядчи підсмажеш вородого танчика. " +
            "Проте не хвилюйся, в нас є ще дочорта сховищ. По секрету топі розповім: вони виглядають як звичайна земля, але з чорним відтінком. Геніально правда? масковіти ніколи зе здогадаються, ги-ги-ги! Там ти завжди зможеш знайти щось корисне. Найближчий буде метрів за тридцять під землею! Тож бажаю успіху і побільше спалених мерзотників. Ще зустрінемось!";
        texts[1] = "Гутен таг майне либе русише Партизанен. Их бин панцер гринадер Пауль фон Вебер. Я знаю що ти мене ніколен тут не знайден, тому що ти тупен швайнен. От якби ми були на українен ланде, мене б давно вже прибили. Данке богу, що мені пощастилен воюванен з вами, невдахами! Дівізія зрадника Фрідріха вже капітулірен, але я не зроблю цого ніколен!" +
            "Цей PANZERSCHRECK буден при мені увесь час. Якщо ви, паскуден, мене знайдете - вам капут. WIR KAPITULIEREN NIE - SIEG ODER TOD, FÜR FÜHRER UND VATERLAND!!!";
        texts[2] = "здесь";
        texts[3] = "";
        texts[4] = ""; 
        texts[5] = "";
        texts[6] = "";
        
        weaponNames[0] = "РПГ - 7";
        weaponNames[1] = "PANZERSCHRECK";
        weaponNames[2] = "М72";
        weaponNames[3] = "ПанцерФауст";
        weaponNames[4] = "НЛАВ";
        weaponNames[5] = "Джава";
        weaponNames[6] = "Матадор";
        
    }

    // Update is called once per frame
    void Update()
    {
        
        currentWeapon = PlayerPrefs.GetInt("GrenadeLaunch");
        weapon.sprite = weapons[currentWeapon];
        text.text = texts[currentWeapon];
        weaponName.text = weaponNames[currentWeapon];
      
    }
}
