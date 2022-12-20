using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
   public enum PathTypes
    {
        linear,
        loop,
        direct
    }
    public PathTypes pathType;
    public int movementDirection = 1;
    public int moveingTo = 0;
    public Transform[] pathElements;
    public bool isDirect;
    public float angleBetween;
    

    public void OnDrawGizmos()
    {
        if (pathElements == null || pathElements.Length < 2)
        {
            return;
        }
        for(var i = 1; i < pathElements.Length; i++)
        {
            Gizmos.DrawLine(pathElements[i - 1].position, pathElements[i].position);

        }
        if (pathType == PathTypes.loop)
        {
            Gizmos.DrawLine(pathElements[0].position, pathElements[pathElements.Length - 1].position);
        }

    }
    public IEnumerator<Transform> GetNextPathPoint()
    {
        if (pathElements == null || pathElements.Length < 1)
        {
            yield break;
        }
        while (true)
        {
            yield return pathElements[moveingTo];
            if (pathElements.Length == 1)
            {
                continue;
            }
            if (pathType == PathTypes.linear)
            {
                isDirect = false;
                if ( moveingTo <= 0)
                {
                    movementDirection = 1;
                }
                else if (moveingTo >= pathElements.Length - 1)
                {
                    movementDirection = -1;
                }

            }
            moveingTo += movementDirection;
            if (pathType == PathTypes.loop)
            {
                isDirect = false;
                if (moveingTo >= pathElements.Length)
                {
                    moveingTo = 0;
                }
                if (moveingTo < 0)
                {
                    moveingTo = pathElements.Length - 1;
                }
            }
            if (pathType == PathTypes.direct)
            {
                isDirect = true;
                if (moveingTo <= 0)
                {
                    movementDirection = 1;
                }
                else if (moveingTo >= pathElements.Length - 1)
                {
                    continue;
                }
            }
            Vector3 targetDir = pathElements[moveingTo].position - pathElements[moveingTo - 1].position;
            Vector3 right = transform.right;
            angleBetween = Vector3.SignedAngle(targetDir, right, Vector3.forward);


        }
    }


}
