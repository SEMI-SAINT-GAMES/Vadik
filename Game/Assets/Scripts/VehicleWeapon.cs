using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleWeapon : MonoBehaviour
{
    public float offSet;
    public float rotateMax;
    public float rotateMin;
    public float minY;
    public GameObject ammo;
    public Transform shotDir;
    public float rotateZ;
    public float rotateZRad;
    bool isDoing;
    public bool isShooting;
    private float timeShot;
    public float startTimeShot;
    public AudioSource shotSoundTigr;
    public GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isDoing = GetComponentInParent<TigrVehicleDiagonal>().isDoing;
        if(isDoing)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (Camera.main.ScreenToWorldPoint(touch.position).y > minY)
                {
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position) - transform.position;
                    touchPosition.z = 0;
                    rotateZRad = Mathf.Atan2(touchPosition.y, touchPosition.x);
                    rotateZ = rotateZRad * Mathf.Rad2Deg;
                    if (rotateZ < rotateMin && rotateZ > -90)
                    {
                        rotateZ = rotateMin;
                    }
                    if (rotateZ > rotateMax && rotateZ < -90)
                    {
                        rotateZ = rotateMax;
                    }

                    transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offSet);
                    
                }
                

            }
           
            if (isShooting)
            {
                Shoot();
            }

        }

        
    }
    public void ShotDown()
    {
        isShooting = true;
        shotSoundTigr.Play();
    }
    public void ShotUp()
    {
        isShooting = false;
        shotSoundTigr.Stop();
    }
    public void Shoot()
    {
        if (timeShot <= 0)
        {
            GameObject am = Instantiate(ammo, shotDir.position, transform.rotation) as GameObject;
            am.GetComponent<AK47Ammo>().isRight = true;
            Instantiate(fire, shotDir.position, shotDir.rotation, gameObject.transform);
            timeShot = startTimeShot;
        }
        else
        {
            timeShot -= Time.deltaTime;
        }
    }
}
