using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class StugnaAmmoIn : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject smoke;
    public StugnaAmmo stugnaAmmo;
    public float smaller;
    
    // Start is called before the first frame update
    void Start()
    {
        stugnaAmmo = GetComponentInParent<StugnaAmmo>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, 0, rotationSpeed * -1f * Time.deltaTime);
        transform.localScale = new Vector3(transform.localScale.x - smaller * Time.deltaTime, transform.localScale.y - smaller * Time.deltaTime, transform.localScale.z - smaller * Time.deltaTime);
        //Invoke("InstanceSmoke", 1.5f);
    }
    private void InstanceSmoke()
    {
       GameObject sm = Instantiate(smoke, transform.position, transform.rotation) as GameObject;
    }
}
