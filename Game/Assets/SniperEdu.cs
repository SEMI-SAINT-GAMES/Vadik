using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SniperEdu : EducationManager
{
    
   
    public int currentSniper;
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
        currentSniper = PlayerPrefs.GetInt("CurrentSniper");
        eduPanel.SetActive(true);
        eduBut.SetActive(true);
        
        StartDialog(dialog[currentSniper]);
        endInThis = false;
    }

    // Update is called once per frame
    void Update()
    {
        //currentSniper = PlayerPrefs.GetInt("CurrentSniper");
        isEnd = GetComponent<SniperControl>().isEnd;
        isFail = GetComponent<SniperControl>().isFail;
        
       
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
            StartFailDialog(failDialog[currentSniper]);
        }
        else if (isEnd)
        {
            StartEndDialog(endDialogCopter[currentSniper]);
            PlayerPrefs.SetFloat("PlayerPosX3", GetComponent<SniperControl>().PosXBuf);
            PlayerPrefs.SetFloat("PlayerPosY3", GetComponent<SniperControl>().PosYBuf);
        }
    }
}
