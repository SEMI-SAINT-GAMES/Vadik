using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyrovJumpExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyExpl", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DestroyExpl()
    {
        Destroy(gameObject);
    }
}
