using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KolProvolka : MonoBehaviour
{
    public Sprite deform;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Control control = collision.GetComponent<Control>();
        if (control != null)
        {
            if (control.inTank == false)
            {
                control.TakeUron(1);
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = deform;
            }
        }
    }
}