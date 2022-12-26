using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraTransform : MonoBehaviour
{
    public float dumpimg;
    public Vector2 offset = new Vector2(2f, 5f);
    public bool isLeft;

    private Transform player;
    public Transform car;
    private int lastX;
    public bool inBattle;
    public float copterSpeed;
    [SerializeField]
    public float leftLimit;
    [SerializeField]
    public float rightLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float upperLimit;


    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(isLeft);
        inBattle = false;

    }
    public void TransformLeft()
    {
        isLeft = true;
    }
    public void TransformRight()
    {
        isLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            TransformRight();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            TransformLeft();
        }


        Vector3 target;
        Vector3 lastPos = transform.position;
            if (isLeft)
            {
             if (car == null)
              {
                target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
              }
             else
              {
                target = new Vector3(car.position.x - offset.x, car.position.y + offset.y, transform.position.z);
              }
            }
            else
            {
            if (car == null)
            {
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(car.position.x + offset.x, car.position.y + offset.y, transform.position.z);
            }
            }
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumpimg * Time.deltaTime);
       // if (Mathf.Abs(currentPosition.y - lastPos.y) > 0.2f)
       // {
            transform.position = currentPosition;
        //}
        //else
        //{
         //   transform.position = new Vector3(currentPosition.x, transform.position.y, currentPosition.z);
        //}
        if (inBattle)
        {
            transform.position = new Vector3
          (Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
          transform.position.y, transform.position.z);
        }
    }
        
        


    
    public void FindPlayer(bool IsLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        lastX = Mathf.RoundToInt(player.position.x);
        if (IsLeft)
        {
            
                transform.position = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
            
           


        }
        else
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        }
        

       


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(rightLimit, upperLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, upperLimit), new Vector2(rightLimit, bottomLimit));
    }

}