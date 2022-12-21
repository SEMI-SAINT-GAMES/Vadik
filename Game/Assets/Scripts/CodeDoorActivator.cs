using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeDoorActivator : MonoBehaviour
{
    public GameObject keypadCanvas;
    public GameObject doorButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Activate()
    {
        keypadCanvas.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Control control = collision.GetComponent<Control>();
        if (control != null)
        {
            doorButton.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Control control = collision.GetComponent<Control>();
        if (control != null)
        {
            doorButton.SetActive(false);
        }
    }
}
