using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleExplosion : MonoBehaviour
{
    public float destroyTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Des", destroyTime);
    }

    // Update is called once per frame
    void Des()
    {
        Destroy(gameObject);
    }
}
