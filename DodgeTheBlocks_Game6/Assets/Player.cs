using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed;
	Rigidbody2D rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		float input = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime;

		//rb.velocity = new Vector2(input * speed, rb.velocity.y);
		rb.MovePosition(rb.position + Vector2.right * input * speed);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Block"))
		{
			collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;

			FindObjectOfType<GameManager>().GameOver();
		}
		
		
	}
}
