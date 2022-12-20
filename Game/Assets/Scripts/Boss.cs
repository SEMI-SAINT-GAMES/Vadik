using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
	public Transform player;
	public bool isJumping = false;
	public bool isFlipped = false;
	public float jumpForce;
	Rigidbody2D rb;

	void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = GetComponent<Rigidbody2D>();
		
    }
    public void Update()
    {
		float dist = Vector2.Distance(transform.position, player.position);
		if (isJumping == true)
        {
			if (isFlipped == true)
            {
				transform.position -= new Vector3(2 * Time.deltaTime, 0, 0);
            }
			else
            {
				transform.position += new Vector3(2 * Time.deltaTime, 0, 0);
			}

        }

	}
    public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x < player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x > player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}
	public void Jump()
    {
		rb.velocity = Vector2.up * jumpForce;
		isJumping = true;
	}
	public void JumpOff()
    {
		isJumping = false;
    }
}
