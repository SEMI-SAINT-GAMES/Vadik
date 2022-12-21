using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EduboxStartActivate : EduBox 
{
    public SceneActivatorL2 scene;
    public TigrVehicleDiagonal tigr;
    // Start is called before the first frame update
    void Start()
    {
        Asign();
        GetDialog();
        scene.isEnd = true;
        if (tigr != null)
        {
            tigr.engineSound.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
