using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyToken", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroyToken()
    {
        Destroy(gameObject);
    }
}
