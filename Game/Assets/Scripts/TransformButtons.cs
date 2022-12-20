using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformButtons : MonoBehaviour
{
    public GameObject[] Buttons;
    public bool inSet;
    public int currentButton;
    public float zoomMin;
    public float zoomMax;
    public Vector2 touchZeroLastPos;
    public Vector2 touchOneLastPos;
    public float distTouch ;
    public float currentDistTouch ;
    public float difference;
    public Text text;
    private string[] texts = new string[2];
    // Start is called before the first frame update
    void Start()
    {
        inSet = false;
        texts[0] = "Натисніть кнопку, яку хочете налаштувати";
        texts[1] = "Натисніть трьома пальцями, щоб підтвертиди";
        text.text = texts[0];

        /*foreach (GameObject but in Buttons)
        {
            PlayerPrefs.SetFloat(but.name + "TransformX", but.transform.position.x);
            PlayerPrefs.SetFloat(but.name + "TransformY", but.transform.position.y);
            PlayerPrefs.SetFloat(but.name + "Scale", but.transform.localScale.x);
        }*/
        LoadTransform();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (inSet)
        {
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;
                Buttons[currentButton].transform.position = touchPosition;
                PlayerPrefs.SetFloat("ButtonTransformX", touchPosition.x);
                PlayerPrefs.SetFloat("ButtonTransformY", touchPosition.y);
                Debug.Log(transform.position);
            }
            else if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);
                touchZeroLastPos = touchZero.position - touchZero.deltaPosition;
                touchOneLastPos = touchOne.position - touchOne.deltaPosition;
                distTouch = (touchZeroLastPos - touchOneLastPos).magnitude;
                currentDistTouch = (touchZero.position - touchOne.position).magnitude;

                difference = currentDistTouch - distTouch;
                Zoom(difference * 0.01f);

            }
            else if (Input.touchCount == 3)
            {
                Done();
                
            }
        }
    }
    void Zoom(float increment)
    {
        Buttons[currentButton].transform.localScale = new Vector3(Mathf.Clamp(Buttons[currentButton].transform.localScale.x + increment, zoomMin, zoomMax),
            Mathf.Clamp(Buttons[currentButton].transform.localScale.y + increment, zoomMin, zoomMax), transform.localScale.z);
    }
    public void LoadTransform()
    {
        foreach (GameObject but in Buttons)
        {
            float posX = PlayerPrefs.GetFloat(but.name + "TransformX");
            float posY = PlayerPrefs.GetFloat(but.name + "TransformY");
            float scale = PlayerPrefs.GetFloat(but.name + "Scale");
            but.transform.position = new Vector3(posX, posY, but.transform.position.z);
            but.transform.localScale = new Vector3(scale, scale, scale);
           but.GetComponent<Image>().color = new Color32(147, 147, 147, 255);
            Debug.Log(but.transform.position.z);
        }
    }
    public void TransformButton()
    {
        if (!inSet)
        {
            currentButton = 0;
            inSet = true;
            Buttons[currentButton].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            text.text = texts[1];
        }
    }
    public void JumpButton()
    {
        if (!inSet)
        {
            currentButton = 1;
            Debug.Log("done");
            inSet = true;
            Buttons[currentButton].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            text.text = texts[1];
        }
    }
    public void JavelButton()
    {
        if (!inSet)
        {
            currentButton = 2;
            inSet = true;
            Buttons[currentButton].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            text.text = texts[1];
        }
    }
    public void TankButton()
    {
        if (!inSet)
        {
            currentButton = 3;
            inSet = true;
            Buttons[currentButton].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            text.text = texts[1];
        }
    }
    public void TankShootButton()
    {
        if (!inSet)
        {
            currentButton = 4;
            inSet = true;
            Buttons[currentButton].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            text.text = texts[1];
        }
    }
    public void ShootButton()
    {
        if (!inSet)
        {
            currentButton = 5;
            inSet = true;
            Buttons[currentButton].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            text.text = texts[1];
        }
    }
    public void DoingButton()
    {
        if (!inSet)
        {
            currentButton = 6;
            inSet = true;
            Buttons[currentButton].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            text.text = texts[1];
        }
    }
    public void Done()
    {
        inSet = false;
        Buttons[currentButton].GetComponent<Image>().color = new Color32(147, 147, 147, 255);
        text.text = texts[0];
        PlayerPrefs.SetFloat(Buttons[currentButton].name + "TransformX", Buttons[currentButton].transform.position.x);
        PlayerPrefs.SetFloat(Buttons[currentButton].name + "TransformY", Buttons[currentButton].transform.position.y);
        PlayerPrefs.SetFloat(Buttons[currentButton].name + "Scale", Buttons[currentButton].transform.localScale.x);



    }
}
