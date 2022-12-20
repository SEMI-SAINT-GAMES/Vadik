using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float destroyTime;
    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyFire", destroyTime);
        if (isRight)
        {
            transform.rotation = Quaternion.Euler(0, 90, -270);
        }
        else
        {
            transform.rotation = Quaternion.Euler(-180, 90, -270);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroyFire()
    {
        Destroy(gameObject);
    }
}
