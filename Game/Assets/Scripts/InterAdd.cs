using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class InterAdd : MonoBehaviour
{
    private InterstitialAd interstitialAd;
    private string initialUnitUd = "ca-app-pub-3940256099942544/1033173712";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnEnable()
    {
        interstitialAd = new InterstitialAd(initialUnitUd);
        AdRequest adRequest = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(adRequest);
    }
    public void ShowAd()
    {
        if (interstitialAd.IsLoaded())
            interstitialAd.Show();
    }
}
