using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndPanel : MonoBehaviour
{
    public Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = PlayerPrefs.GetInt("CoinsCount").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
