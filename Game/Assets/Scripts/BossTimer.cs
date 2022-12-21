using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTimer : MonoBehaviour
{
    public float timerTime;
    
    public GameObject boss;
    bool bossIsActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerTime <= 0 && !bossIsActive)
        {
            bossIsActive = true;
            boss.SetActive(true);
        }
        else
        {
            timerTime -= Time.deltaTime;
        }
    }
}
