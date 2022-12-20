using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform startPoint;
    private float startPointPos;
    private int yPos;
    private float xPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startPointPos = startPoint.position.y;

        for (int i = yPos; i > startPointPos; i++)
        {

        }
    }
}
