using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovGroundDiagonal : MonoBehaviour
{
    public enum MovementType
    {
        moveing,
        lerping
    }
    public MovementType type = MovementType.moveing;
    public MovementPath myPath;
    public float speed = 1;
    public float maxDist = .1f;
    private IEnumerator<Transform> PointInPath;
    
    public float rotationSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        Asign();

    }
    public void Asign()
    {
        if (myPath == null)
        {
            Debug.Log("НЕТ ПУТИ");
            return;
        }
        PointInPath = myPath.GetNextPathPoint();
        PointInPath.MoveNext();
        if (PointInPath.Current == null)
        {
            Debug.Log("Nuzhny Tochki");
            return;

        }
        transform.position = PointInPath.Current.position;
    }

    // Update is called once per frame
    void Update()
    {
        Do();

    }
    public void Do()
    {
        if (PointInPath == null || PointInPath.Current == null)
        {
            Debug.Log("PUSTO");
            return;
        }
        if (type == MovementType.moveing)
        {
            transform.position = Vector3.MoveTowards(transform.position, PointInPath.Current.position, speed * Time.deltaTime);
        }
        else if (type == MovementType.lerping)
        {
            transform.position = Vector3.Lerp(transform.position, PointInPath.Current.position, speed * Time.deltaTime);
        }
        var distanceSquare = (transform.position - PointInPath.Current.position).sqrMagnitude;
        if (distanceSquare < maxDist * maxDist)
        {
            if (!myPath.isDirect)
            {
                PointInPath.MoveNext();
            }
            else
            {
                if (myPath.moveingTo < myPath.pathElements.Length - 1)
                {
                    GoNext();
                }


            }
        }
        
    }
    public void GoNext()
    {
        PointInPath.MoveNext();
    }

}
