using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public float destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyFire", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void DestroyFire()
    {
        gameObject.SetActive(false);
    }
}
