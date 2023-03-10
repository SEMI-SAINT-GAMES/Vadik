using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponCollectObjects : MonoBehaviour
{
    public Sprite[] weapons;
    private string[] texts = new string[9];
    private string[] weaponNames = new string[9];
    public Text text;
    public int currentWeapon;
    public Image weapon;
   
   


    // Start is called before the first frame update
    void Start()
    {
        
        currentWeapon = PlayerPrefs.GetInt("CurrentWeapon");
        texts[0] = "hello";
        texts[1] = "1941: ой на знаю чи залишусь я живим після бою зі сраними фрицами, однак якщо хтось знайде цей конверт, мені буде приємно. Мене звуть Микола і я пішов на фронт щоб захистити свою" +
            "землю від окупантів. Більше ніж <<саветів>> я ненавиджу тільки гітлерівців. Як тільки покінчу з ними - одразу ж візьмуся за червоних окупантів. Хай живе вільна Україна. Разом із письмом прилагаю <<мосінку>>. Може знадобитися українським партизанам!";
        texts[2] = "19.03.1942: Хало, майн наме Фрідріх унд іх бін доічен зольдатен котрий трошки шпрахе украініш. Майн батальон був окружен унд іх ніхт знаю вас буде зі мною. Майне лібе дойчланд" +
            "перетворилася у діктатурен. Тепер ми окупантен унд весь світ нас ненавідетен. Іх ніхт хочу, щоб ми виграли цю війну. Дойчланд " +
            "повинна капітулірен. Я вже все вирішен та буду стрелятен собі у голову. Сподіваюсь, що русіш не стануть такімен як ми. Нехай мій <<Шмайстер>> достанеться хорошій людинен. Вільна Дойчланд убер аллес";
        texts[3] = "Привіт друже, якщо ти це читаєш, напевно я вже мочу окупантів десь у маскві. Орки вбили мою родину і я вже нічого не боюсь, тому і пішов партизанити " +
            "у тил цим покидькам. Знаю шо це сховище зміг би знайти тільки українець, тому зилишаю тобі цей калаш 74. Мій батько вкрав його, коли служив в арміі, а тепер ти вбиватимеш сучасних нацистів." +
            "сподіваюсь тобі знадобиться і ти застрелиш якомога більше ванєчек. Дай тобі боже сто років життя. Слава Україні. Партизан Артем. Місто Маріуполь";
        texts[4] = "Схрон номир 47. Аставляю здесь мой ручной пулимет калашникава на случий вайнь! с пиндосами (Укрь! то да нас ни дайдут ни в коим случии. вь! вапще их малинькую армею видели, ахахахахахах)" +
            "имя мае сонек (на случий есле забуду ахахаха все равно некто мой схрончик нинайдет и амерь! стопрацентав максемум ваван). да сдрастувуит виликая раися. мь! самая крутая и магучая страна и армея в мире. сийчас адним махам" +
            "зохватим Украину и пайдем на ивропу наступать, к вечиру навернае уже возле омерики будем. вот идинствиное што миня валнует так єто то што нидавна в гозете прачитал што фамилия у миня украинская - шешкавчук. но ничяго страшнага, " +
            "сминю ие лучще на чиста раисянскую - гавнов!. ладна пашол я писать свои уть!рашнь!е книги. слава раиси!";
        texts[5] = "Вітаю тебе Сталкер! Моє імʼя Василь ";
        texts[6] = "";
        texts[7] = "";
        texts[8] = "";
        weaponNames[0] = "Калаш 47";
        weaponNames[1] = "Мосінка";
        weaponNames[2] = "Шмайстер (MP40)";
        weaponNames[3] = "Калаш 74";
        weaponNames[4] = "Пулемет калашникова";
        weaponNames[5] = "Винторез";
        weaponNames[6] = "Арка (М4)";
        weaponNames[7] = "Фамас";
        weaponNames[8] = "Ж36";
        text.text = texts[currentWeapon];
        weapon.sprite = weapons[currentWeapon];


    }

    // Update is called once per frame
    void Update()
    {
        //currentWeapon = PlayerPrefs.GetInt("CurrentWeapon");
       
       
        
    }
   
}
