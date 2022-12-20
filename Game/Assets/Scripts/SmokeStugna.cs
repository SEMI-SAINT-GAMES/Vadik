using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeStugna : MonoBehaviour
{
    public float rotationSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySmoke", 0.2f);
    }
    void Update()
    {
       transform.Rotate(0, 0, rotationSpeed * -1f * Time.deltaTime);
    }
    private void DestroySmoke()
    {
        Destroy(gameObject);
    }
}
