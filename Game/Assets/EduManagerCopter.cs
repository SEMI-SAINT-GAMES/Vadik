using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EduManagerCopter : EducationManager
{
   /* private string[] textsStart = new string[2];
    private string[] textsEnd = new string[2];
    private string[] textsHeroStart = new string[2];
    private string[] textsHeroEnd = new string[2];
    public Text text;
    public Text buttonText;*/
    public int currentCopter;
    public bool isEnd;
    public Dialog[] dialog;
    public EndDialogCopter [] endDialogCopter;
    bool endInThis;
    

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        answers = new Queue<string>();
        eduPanel.SetActive(true);
        eduBut.SetActive(true);
        currentCopter = PlayerPrefs.GetInt("CurrentKopter");
        /*textsStart[0] = "старт";
        textsHeroStart[0] = "старт1";
        textsEnd[0] = "stop";
        textsHeroEnd[0] = "stop1";*/
        StartDialog(dialog[currentCopter]);
        endInThis = false;
    }

    // Update is called once per frame
    void Update()
    {
        isEnd = GetComponent<KopterController>().isEnd;
        currentCopter = PlayerPrefs.GetInt("CurrentKopter");
       if (isEnd && !endInThis)
        {
            StartEndDialog(endDialogCopter[currentCopter]);
           endInThis = true;
        }
        
    }
    public void StartEndDialog(EndDialogCopter dialog)
    {
        sentences.Clear();
        answers.Clear();
        eduPanel.SetActive(true);

        foto.sprite = dialog.foto;
        foreach (string sentence in dialog.sentences)
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
}
