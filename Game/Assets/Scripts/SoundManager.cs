using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager snd;
    private AudioSource audioSrc;
    
    
    // Start is called before the first frame update
    void Start()
    {
        snd = this;
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
