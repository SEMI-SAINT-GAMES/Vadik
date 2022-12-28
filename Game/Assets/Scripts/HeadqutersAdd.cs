using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class HeadqutersAdd : MonoBehaviour
{

    private void Awake()
    {
        MobileAds.Initialize(initStatus => { });
    }
}
