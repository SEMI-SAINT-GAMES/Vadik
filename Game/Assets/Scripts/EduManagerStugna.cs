using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EduManagerStugna : EducationManager
{
    public int currentStugna;
    public bool isEnd;
    public bool isFail;
    public Dialog[] dialog;
    public EndDialogCopter[] endDialogCopter;
    public FailDialog[] failDialog;
    public bool endInThis;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        answers = new Queue<string>();
        currentStugna = PlayerPrefs.GetInt("CurrentStugna");
        eduPanel.SetActive(true);
        eduBut.SetActive(true);

        StartDialog(dialog[currentStugna]);
        endInThis = false;
    }

    // Update is called once per frame
    void Update()
    {
        //currentSniper = PlayerPrefs.GetInt("CurrentSniper");
        isEnd = GetComponent<StugnaAimControl>().isEnd;
        isFail = GetComponent<StugnaAimControl>().isFail;


        if (isFail && !endInThis)
        {
            Invoke("DialogDelay", 1f);
            endInThis = true;
        }
        if (isEnd && !endInThis)
        {
            Invoke("DialogDelay", 1f);
            endInThis = true;
        }
    }
    public void StartEndDialog(EndDialogCopter dialog)
    {
        sentences.Clear();
        answers.Clear();
        eduPanel.SetActive(true);
        eduBut.SetActive(true);

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
    public void StartFailDialog(FailDialog dialog)
    {
        sentences.Clear();
        answers.Clear();
        eduPanel.SetActive(true);
        eduBut.SetActive(true);

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
    public void DialogDelay()
    {
        if (isFail)
        {
            StartFailDialog(failDialog[currentStugna]);
        }
        else if (isEnd)
        {
            StartEndDialog(endDialogCopter[currentStugna]);
            PlayerPrefs.SetFloat("PlayerPosX2", GetComponent<StugnaAimControl>().PosXBuf);
            PlayerPrefs.SetFloat("PlayerPosY2", GetComponent<StugnaAimControl>().PosYBuf);
        }
    }
}
