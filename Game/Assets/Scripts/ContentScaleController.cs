using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentScaleController : MonoBehaviour
{
    public float zoomMin;
    public float zoomMax;
    public Vector2 touchZeroLastPos;
    public Vector2 touchOneLastPos;
    public float distTouch;
    public float currentDistTouch;
    public float difference;
    public float sensivity;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Input.touchCount == 2)
         {
             Touch touchZero = Input.GetTouch(0);
             Touch touchOne = Input.GetTouch(1);
             touchZeroLastPos = touchZero.position - touchZero.deltaPosition;
             touchOneLastPos = touchOne.position - touchOne.deltaPosition;
             distTouch = (touchZeroLastPos - touchOneLastPos).magnitude;
             currentDistTouch = (touchZero.position - touchOne.position).magnitude;

             difference = currentDistTouch - distTouch;
             Zoom(difference * sensivity);

         }*/
        transform.localScale = new Vector3(slider.value + 0.4f, slider.value + 0.4f, slider.value + 0.4f);
    }
    void Zoom(float increment)
    {
        this.transform.localScale = new Vector3(Mathf.Clamp(this.transform.localScale.x + increment, zoomMin, zoomMax),
            Mathf.Clamp (this.transform.localScale.y + increment, zoomMin, zoomMax), transform.localScale.z);
    }
}
