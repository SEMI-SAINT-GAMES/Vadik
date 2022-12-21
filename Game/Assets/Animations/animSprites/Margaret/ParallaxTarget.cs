using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxTarget : MonoBehaviour
{
    public float speed;
    public bool isRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 2000 && isRight)
        {
            isRight = false;
        }
        if (transform.position.x < 0 && !isRight)
        {
            isRight = true;
        }
        if (isRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
}
