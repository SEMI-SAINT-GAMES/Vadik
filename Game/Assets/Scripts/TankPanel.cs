using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankPanel : MonoBehaviour
{
    public Sprite[] weapons;
    private string[] texts = new string[6];
    private string[] weaponNames = new string[6];
    public Text text;
    public Text weaponName;
    public int currentWeapon;
    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        texts[0] = "привет";
        texts[1] = "Брати мої та сестри, до вас звертається командир екіпажу <<Чайка>> Першої такової роти Першої Запорізької дивізіі арміі Української Народної Республіки Капітан Богдан Цілуйко. Інформація про нашу роту є надсекретною" +
            " через те, що червоні навіть і не знають про захоплений нами англіський танк марк 5. Було то у жовтні 1920 року, за даними нашої розвідки камуняки захопили у білящів новенький танчик під каховкою, який англійці передали у " +
            "раісянську імперію ще за часів Великої Війни. Почесавши репу, <<адепти ленінскай сєкти>> одразу кинули його на бої під Проскури проти нас, де була найгарячіша точка. Однак одного чудового вечора, мій молодший лейтенант Микола зі своєю командою завітав у тил до маскаликів влаштував їм " +
            "справжнє пекло на землі. Нащастя всі червоні дупи були знищені, однак новітня броньована машина була захоплена і тепер наша дивізія мчить на ній до маскви. Нажаль наших сил буде замало, і тому ми залишимо цей танк у сховищі. Сподіваюсь, ти, щирий козаче завершиш нашу справу та вʼбєш всіх цих покидьків " +
            "за допомогою цієї апаратури. Нехай щастить.";
        texts[2] = "здесь";
        texts[3] = "";
        texts[4] = "";
        texts[5] = "";
        

        weaponNames[0] = "T64";
        weaponNames[1] = "Mark-5";
        weaponNames[2] = "Abrams";
        weaponNames[3] = "T14 <<Говнята>>";
        weaponNames[4] = "Тигр";
        weaponNames[5] = "Леопард";
       

    }

    // Update is called once per frame
    void Update()
    {

        currentWeapon = PlayerPrefs.GetInt("CurrentTank");
        weapon.GetComponent<SpriteRenderer>().sprite = weapons[currentWeapon];
        text.text = texts[currentWeapon];
        weaponName.text = weaponNames[currentWeapon];
    }
}
