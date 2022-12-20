using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StugnaDistance : MonoBehaviour
{
    public float distance;
    private float distanceObject;
    public Text distanceText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Mathf.Abs(transform.position.z - distanceObject);
        distanceText.text = "ВІДСТАНЬ =  " + distance + "  М  " + "  ЖИВЛЕННЯ   12,6   25,4    ";

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        distanceObject = collision.transform.position.z;
        
    }
}
