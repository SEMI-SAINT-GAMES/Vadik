using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MargaretInsByHero : MonoBehaviour
{
    public GameObject margaret;
    public Transform tigr;

    public void MargaretIns()
    {
        margaret.transform.position = tigr.position + new Vector3(0, 1.1f, 0);
        Vector3 theScale = margaret.transform.localScale;
        theScale.x *= -1;
        margaret.transform.localScale = theScale;
        margaret.SetActive(true);
        margaret.GetComponent<MargaretL2>().ToWin();
    }
}
