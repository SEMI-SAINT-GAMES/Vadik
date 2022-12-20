using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentTransformMap : MonoBehaviour
{
    public Vector3[] startPos;
    public int levelComplete;
    public Sprite[] maps;
    public Image scrollView;
    public Image[] mas1;
    private Image[,] mas2;

    // Start is called before the first frame update
    void Start()
    {
        mas2 = new Image[10, 2] { { mas1[0], mas1[1] }, { mas1[2], mas1[3] }, { mas1[4], mas1[5] }, { mas1[6], mas1[7] }, { mas1[8], mas1[9] }, { mas1[10], mas1[11] }, { mas1[12], mas1[13] }, { mas1[14], mas1[15] }, { mas1[16], mas1[17] }, { mas1[18], mas1[19] } };
        levelComplete = PlayerPrefs.GetInt("LevelComplete"); 
        //transform.position = startPos[levelComplete];
        scrollView.sprite = maps[levelComplete];
        ArrowsAsign();
        Debug.Log(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ArrowsAsign()
    {
        for (int i = 0; i < 10;  i++)
        {
            for (int k = 0; k < 2; k++)
            {
                if (i < levelComplete)
                {
                    mas2[i, k].color = Color.blue;
                }
                else if (i == levelComplete)
                {
                    mas2[i, k].color = Color.red;
                }
                else if (i > levelComplete)
                {
                    mas2[i, k].color = Color.grey;
                }

            }
        }
    }
}
