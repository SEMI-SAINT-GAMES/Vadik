using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StugnaAmmo : MonoBehaviour
{
    public float speed;
    private Transform aim;
    public float rotationSpeed;
    public GameObject explosion;
    public float smaller;
    public float dumping;
    private Quaternion q;
    

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyAmmoStugna", 10f);
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        aim = GameObject.FindGameObjectWithTag("Aim").transform;
        Vector3 target = new Vector3(aim.position.x, aim.position.y, transform.position.z);
        Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
        transform.position = new Vector3(currentPosition.x, currentPosition.y, transform.position.z + speed * Time.deltaTime);   //new Vector3 (vector.x, vector.y, transform.position.z + speed * Time.deltaTime);
        transform.Rotate(0, 0, rotationSpeed * -1f * Time.deltaTime);
        //transform.localScale = new Vector3(transform.localScale.x - smaller * Time.deltaTime, transform.localScale.y - smaller * Time.deltaTime, transform.localScale.z - smaller * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider collision)
    {
        StugnaPatrool stugnaPatrool = collision.GetComponent<StugnaPatrool>();
        if (stugnaPatrool != null)
        {
            stugnaPatrool.Die();
            
            GameObject newObj = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            newObj.transform.localScale = new Vector3(3, 3, 0);
        }
        DestroyAmmoStugna();




    }
    public void DestroyAmmoStugna()
    {
        Destroy(gameObject);
    }





}

