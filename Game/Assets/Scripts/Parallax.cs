using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] Transform followingTarget;
    [SerializeField, Range(0f, 2f)] float parallaxStrenght = 0.1f;
    [SerializeField] bool disableVerticalParallax;
    Vector3 targetPreviosPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (!followingTarget)
            followingTarget = Camera.main.transform;
        targetPreviosPosition = followingTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        var delta = followingTarget.position - targetPreviosPosition;
        if (disableVerticalParallax)
            delta.y = 0;
        targetPreviosPosition = followingTarget.position;
        transform.position += delta * -parallaxStrenght;

        
    }
}
