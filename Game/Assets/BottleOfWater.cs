using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleOfWater : MonoBehaviour
{
    CollectObjectsHero collect;
    bool isHold;
    bool colActiv;
  

    // Start is called before the first frame update
    void Start()
    {
        collect = GameObject.FindGameObjectWithTag("Player").GetComponent<CollectObjectsHero>();
       
    }

    // Update is called once per frame
    void Update()
    {
        isHold = collect.isHold;
        if (isHold && !colActiv)
        {
           
            colActiv = true;
        }
    }
   
}
