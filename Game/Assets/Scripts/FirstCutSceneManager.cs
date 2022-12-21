using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCutSceneManager : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        if (player.position.x > 3)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
