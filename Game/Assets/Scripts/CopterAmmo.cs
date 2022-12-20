using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopterAmmo : MonoBehaviour
{
    public float destroyTime;
    public float rayDistance;
    private float rotate = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("DestroyAmmo", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (rotate <= 360)
        {
            transform.rotation = Quaternion.Euler(0, 0, rotate);
            rotate += 1;
        }
    }
    private void DestroyAmmo()
    {
        Destroy(gameObject);
    }
    
    
}
