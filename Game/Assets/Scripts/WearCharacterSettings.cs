using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearCharacterSettings : MonoBehaviour
{
    public GameObject helmet;
    public GameObject[] torso;
    public GameObject[] pans;
    public Sprite[] helmets;
    public Sprite[] torsoPixel;
    public Sprite[] torsoMulticam;
    public Sprite[] torsoMarpat;
    public Sprite[,] torsos;
    public Sprite[] pansMulticam;
    public Sprite[] pansPixel;
    public Sprite[] pansMarpat;
    public Sprite[,] panses;
    public int curHelmet;
    public int curTorso;
    public int curPans;
    public GameObject[] helmetBut;
    public GameObject[] torsoBut;
    public GameObject[] pansBut;
    public string butNameHelmet;
    public string butNameTorso;
    public string ButNamePans;
    public GameObject confilmPanelHelmet;
    public GameObject confilmPanelTorso;
    public GameObject confilmPanelPans;
    public AudioSource wearSound;
    bool isStart = true;
    public bool inSave;

    // Start is called before the first frame update
    void Start()
    {
        torsos = new Sprite[3, 9] { { torsoPixel[0], torsoPixel[1], torsoPixel[2], torsoPixel[3], torsoPixel[4], torsoPixel[5] , torsoPixel[6] , torsoPixel[7] , torsoPixel[8] }, { torsoMulticam[0], torsoMulticam[1], torsoMulticam[2], torsoMulticam[3], torsoMulticam[4], torsoMulticam[5], torsoMulticam[6], torsoMulticam[7], torsoMulticam[8]}, { torsoMarpat[0], torsoMarpat[1], torsoMarpat[2], torsoMarpat[3], torsoMarpat[4], torsoMarpat[5], torsoMarpat[6], torsoMarpat[7], torsoMarpat[8] } };
        panses = new Sprite[3, 4] { { pansPixel[0], pansPixel[1], pansPixel[2], pansPixel[3] }, { pansMulticam[0], pansMulticam[1], pansMulticam[2], pansMulticam[3] }, { pansMarpat[0], pansMarpat[1], pansMarpat[2], pansMarpat[3]} };
        if (inSave)
        {
            curHelmet = PlayerPrefs.GetInt("CurrentHelmet");
            curTorso = PlayerPrefs.GetInt("CurrentTorso");
            curPans = PlayerPrefs.GetInt("CurrentPans");
        }
        CurWear1();
        
        

    }

    // Update is called once per frame
    void Update()
    {
        butNameHelmet = PlayerPrefs.GetString("OpenHelmet");
        butNameTorso = PlayerPrefs.GetString("OpenTorso");
        ButNamePans = PlayerPrefs.GetString("OpenPans");
    }
    public void CurWear1()
    {
        helmet.GetComponent<SpriteRenderer>().sprite = helmets[curHelmet];
        //torso
        for (int i = 0; i < 9; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                if (k == curTorso)
                {
                    torso[i].GetComponent<SpriteRenderer>().sprite = torsos[k, i];
                   

                }
            }
        }
        for (int i = 0; i < pans.Length; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                if (k == curPans)
                {
                    pans[i].GetComponent<SpriteRenderer>().sprite = panses[k, i];
                }
            }
        }
        if (!isStart)
        {
            wearSound.Play();
        }
        isStart = false;
    }
    public void PixelHelmet()
    {
         curHelmet = 0;
        PlayerPrefs.SetInt("CurrentHelmet", curHelmet);
         CurWear1();
    }
    public void MultiHelmet()
    {
        if (butNameHelmet.Contains("MultiHelmet"))
        {
            curHelmet = 1;
            PlayerPrefs.SetInt("CurrentHelmet", curHelmet);
            CurWear1();
        }
        else
        {
            confilmPanelHelmet.GetComponent<ConfilmPanel>().currentConfilm = 0;
            confilmPanelHelmet.SetActive(true);
            
        }
    }
    public void MarpatHelmet()
    {
        if (butNameHelmet.Contains("MarpatHelmet"))
        {
            curHelmet = 2;
            PlayerPrefs.SetInt("CurrentHelmet", curHelmet);
            CurWear1();
        }
        else
        {
            confilmPanelHelmet.GetComponent<ConfilmPanel>().currentConfilm = 1;
            confilmPanelHelmet.SetActive(true);
           

        }
    }
    public void PixelTorso()
    {
       
        curTorso = 0;
        PlayerPrefs.SetInt("CurrentTorso", curTorso);
        CurWear1();
    }
    public void MultiTorso()
    {
        if (butNameTorso.Contains("MultiTorso"))
        {
            curTorso = 1;
            PlayerPrefs.SetInt("CurrentTorso", curTorso);
            CurWear1();
        }
        else
        {
            confilmPanelTorso.GetComponent<ConfilmPanelTorso>().currentConfilm = 0;
            confilmPanelTorso.SetActive(true);
            
        }
    }
    public void MarpatTorso()
    {
        if (butNameTorso.Contains("MarpatTorso"))
        {
            curTorso = 2;
            PlayerPrefs.SetInt("CurrentTorso", curTorso);
            CurWear1();
        }
        else
        {
            confilmPanelTorso.GetComponent<ConfilmPanelTorso>().currentConfilm = 1;
            confilmPanelTorso.SetActive(true);
            
        }
    }
    public void PixelPans()
    {
        curPans = 0;
        PlayerPrefs.SetInt("CurrentPans", curPans);
        CurWear1();
    }
    
   
    public void MultiPans()
    {
        if (ButNamePans.Contains("MultiPans"))
        {
            curPans = 1;
            PlayerPrefs.SetInt("CurrentPans", curPans);
            CurWear1();
        }
        else
        {
            confilmPanelPans.GetComponent<ConfilmPanelPans>().currentConfilm = 0;
            confilmPanelPans.SetActive(true);
            
        }
    }
    public void MarpatPans()
    {
        if (ButNamePans.Contains("MarpatPans"))
        {
            curPans = 2;
            PlayerPrefs.SetInt("CurrentPans", curPans);
            CurWear1();
        }
        else
        {
            confilmPanelPans.GetComponent<ConfilmPanelPans>().currentConfilm = 1;
            confilmPanelPans.SetActive(true);
            
        }
    }
}
