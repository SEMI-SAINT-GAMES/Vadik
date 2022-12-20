using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class FailDialog 
{
    public Sprite foto;
    [TextArea(3, 10)]
    public string[] sentences;
    public string[] answers;
}
