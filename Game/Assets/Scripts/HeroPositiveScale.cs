using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroPositiveScale : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.localScale = new Vector3(0.1530221f, 0.1530221f, 0.1530221f);
        player.transform.position = new Vector3(965.22f, 8.11f, -0.49f);
        player.GetComponent<Animator>().SetBool("WeaponDown", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
