using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EducationManager : MonoBehaviour
{
    public int currentEdu;

    public GameObject eduPanel;
    public GameObject eduBut;
    public Text text;
    public Text hrText;
    private string[] textsOf = new string[20];
    private string[] textsHero = new string[20];
    private string howToTrans;
    public Image foto;
    public GameObject[] eduBox;
    public Queue<string> sentences;
    public Queue<string> answers;
    public Button hrAnswer;
    public bool isEndButton;
    public AudioSource[] sound;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        answers = new Queue<string>();
        //PlayerPrefs.SetInt("CurrentEdu", 0);//TEST, УБРАТЬ ПОСЛЕ БИЛДИНГА!!!
       /* if (PlayerPrefs.GetInt("CurrentEdu") > 0)
        {
            eduPanel.SetActive(false);
        }
        else
        {
            eduPanel.SetActive(true);
            PlayerPrefs.SetString("CurrentWeaponStr", "0");
        }*/
        textsOf[0] = "Слава Україні боєць! Я полковник Васильківський, буду з тобою завжди на зв'язку. Сподіваюся як бігатти, стрибати і стриляти ти знаєш?";
        textsOf[1] = "Дякуюємо богові хоч цьому вчити не треба. Зброю ми тобі дали, тож вперед у наступ на белгарад! Якщо побачиш ворога, одразу стріляй цю мразоту і не забувай поповнювати свої підсумки магазинами!";
        textsOf[2] = "Ну ось і настав час перевірити як ти стріляєш і орієнтуєшся у бою. Попереду ворожий солдат. Влучаєш ти мітко, але памʼятай: 5 пострілів - це не завжди 5 попадань, навіть якщо стріляєш у бік ворога.";
        textsOf[3] = "Завжди памʼятай про своє здоровʼя! Збирай аптечки та лікуйся, бо в бою, іноді можуть здоровенько поранити. Також раджу тобі щоразу звертати увагу на підземні ходи. Там часто бувають різні нички";
        textsOf[4] = "Так виглядають ворожі штаби. Твоє завдання захоплювати їх і піднімати державний прапор. Після підняття прапору ми збережемо твої кординати.";
        textsOf[5] = "Будь обережним синку. Наступний штаб охороняє два орка на чолі з офіцером. Останній має кращу броню і вже не буде впадати у ступор і просто палити, коли тебе побачить, а бігтиме за тобою поки не помре!";
        textsOf[6] = "Партизани розповідали, що бачили десь тут, у підземних ходах, схрон, нібито ще другої світоіої. Не знаю правда чи ні, але раджу тобі пошукати. Може знайдеш щось цікаве";
        textsOf[7] = "Розвідка доповіла мені, що неподалік перебувають ворожі танки, тому у цьому боксі ми залишили для тебе щось цікаве.Відкрий його й покажи ворожим коритам що таке справжня українська лють";
        textsOf[8] = "Бачу ти вже знайшов набої! Молодець! Швидко вчишся. Забув ще сказати: не підходь до танка близько, бо він почне палити з кулемету. Тримай дистанцію!";
        textsOf[9] = "Хо Хо, як гарно горить. Прекрасне влучання синку. Шукай наші сховища з боєприпасами а також подібні бокси з новим озброєнням. Але не сильно захоплюйся, бо пострілів не завжди буває достатньо!";
        textsOf[10] = "Залишився останній ривок синку і вже будемо у бєлгараді! Аби забезпечити наш наступ треба розбити ворожу артилерію.Міномет вже готовий! Твоє завдання підняти коптер у небо і позначити ворога!";
        textsOf[11] = "Ну ось і все! Вже бєлгород! Відпочинь трошки, переведи дух і вперед до наступу. Раіся все ще велика.";
        textsOf[12] = "";
        textsOf[13] = "";
        textsOf[14] = "";
        textsOf[15] = "";
        textsOf[16] = "";
        textsOf[17] = "";

        textsHero[0] = "Звісно знаю";
        textsHero[1] = "Слухаюсь";
        textsHero[2] = "Оу ніштяк, дякую";
        textsHero[3] = "Я думав я невмеручій";
        textsHero[4] = "Зрозуміло";
        textsHero[6] = "Добре, гляну";
        textsHero[5] = "Мда, буде весело";
        textsHero[10] = "Буде зроблено!";
        textsHero[11] = "Далі буде";
        text.text = textsOf[currentEdu];
        hrText.text = textsHero[currentEdu];
       
           
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartDialog(Dialog dialog)
    {
        sentences.Clear();
        answers.Clear();
        eduPanel.SetActive(true);
        eduBut.SetActive(true);
        foto.sprite = dialog.foto;
        foreach(string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (string answer in dialog.answers)
        {
            answers.Enqueue(answer);
        }
        DisplayNextSentence();
        //Debug.Log(sentences);
    }
    public void DisplayNextSentence()
    {
        hrAnswer.interactable = false;
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }
        string sentence = sentences.Dequeue();
        string answer = answers.Dequeue();
        StartCoroutine(TypeSentence(sentence, answer));
        
       
    }
    IEnumerator TypeSentence(string sentence,string answer)
    {
        int rand = Random.Range(0, sound.Length - 1);
        text.text = "";
        hrText.text = "";
        sound[rand].Play();

        foreach (char letter in sentence.ToCharArray())
        {
            text.text += letter;
            yield return null;
        }


        sound[rand].Stop();
        yield return new WaitForEndOfFrame();

        foreach (char letter in answer.ToCharArray())
        {
            hrText.text += letter;
            yield return null;
        }

        hrAnswer.interactable = true;
        yield return null;



    }
   
    public void EndDialog()
    {
        eduPanel.SetActive(false);
        eduBut.SetActive(false);
        
    }
    

    
    
        
    
}
