using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public int curentSniper;
    public float[] saveX;
    public float[] saveY;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Control control = collision.GetComponent<Control>();
        if (control != null)
        {
            PlayerPrefs.SetInt("CurrentSniper", curentSniper);
            control.Invoke("GajetPanel", 1f);
            control.speed = 0;
            PlayerPrefs.SetFloat("PlayerPosXBuf", transform.position.x + saveX[curentSniper]);
            PlayerPrefs.SetFloat("PlayerPosYBuf", transform.position.y + saveY[curentSniper]);
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
