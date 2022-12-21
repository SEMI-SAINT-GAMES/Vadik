using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinManager : MonoBehaviour
{
    public int coinsCount;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        coinsCount = PlayerPrefs.GetInt("CoinsCount");
        text.text = coinsCount.ToString();
        Debug.Log(coinsCount.ToString());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void CoinPlus(int price)
    {
        coinsCount += price;
        text.text = coinsCount.ToString();
        PlayerPrefs.SetInt("CoinsCount", coinsCount);
    }
}
