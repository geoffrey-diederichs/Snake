using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
	private int startSize = 3;
	private int growRate = 1;
	private Vector2 direction;

	private List<Transform> snakeTail;
	public Transform segmentModel;

	private void Start()
	{
		direction = Vector2.right;	

		snakeTail = new List<Transform>();
		snakeTail.Add(this.transform);

		Grow(this.startSize);
	}

	private void Update()
	{
		if ((Input.GetKeyDown(KeyCode.UpArrow)) && (direction != Vector2.down))
		{
			direction = Vector2.up;
		} 
		else if ((Input.GetKeyDown(KeyCode.DownArrow)) && (direction != Vector2.up))
		{
        		direction = Vector2.down;
		}
 		if ((Input.GetKeyDown(KeyCode.LeftArrow)) && (direction != Vector2.right))      
 		{
 			direction = Vector2.left;
 		}
		if ((Input.GetKeyDown(KeyCode.RightArrow)) && (direction != Vector2.left))
		{
			direction = Vector2.right;
		}
	}

	private void FixedUpdate()
	{
		for (int i = snakeTail.Count-1; i > 0; i--)
		{
			snakeTail[i].position = snakeTail[i-1].position;
		}

		this.transform.position = new Vector3(Mathf.Round(this.transform.position.x)+direction.x, Mathf.Round(this.transform.position.y)+direction.y, 0.0f);	
	}
	
	private void Grow(int rate)
	{
		for (int i = 0; i < rate; i++)
		{
			Transform newSegment = Instantiate(this.segmentModel);
        		newSegment.position = snakeTail[snakeTail.Count-1].position;
                                                                             
        		snakeTail.Add(newSegment);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Apple")
		{
			Grow(this.growRate);
		}
		else if ((collision.gameObject.tag == "Limit") || (collision.gameObject.tag == "Snake"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
