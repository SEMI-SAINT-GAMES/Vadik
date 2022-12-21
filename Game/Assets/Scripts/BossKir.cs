using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKir : MonoBehaviour
{
	public bool isFlipped;
	public Transform player;
	// Start is called before the first frame update
	void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}
}
