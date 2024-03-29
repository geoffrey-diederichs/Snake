using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
	private int startSize = 3;
	private int growRate = 1;
	public int doubleGrow = 1;
	public int doubleGrowTimeLimit = 100;
	private Vector2 direction;

	public Score score;
	public Alert alert;

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
		if ((Input.GetKeyDown(KeyCode.UpArrow)) && (this.direction != Vector2.down))
		{
			this.direction = Vector2.up;
		} 
		else if ((Input.GetKeyDown(KeyCode.DownArrow)) && (this.direction != Vector2.up))
		{
        		this.direction = Vector2.down;
		}
 		if ((Input.GetKeyDown(KeyCode.LeftArrow)) && (this.direction != Vector2.right))      
 		{
 			this.direction = Vector2.left;
 		}
		if ((Input.GetKeyDown(KeyCode.RightArrow)) && (this.direction != Vector2.left))
		{
			this.direction = Vector2.right;
		}
	}

	private void FixedUpdate()
	{
		if ((doubleGrow == 2) && (doubleGrowTimeLimit > 0))
		{
			doubleGrowTimeLimit--;
		}
		else if ((doubleGrow == 2) && (doubleGrowTimeLimit == 0))
		{
			doubleGrow = 1;
			doubleGrowTimeLimit = 100;
			alert.setDouble(false);
		}
		else
		{
			int rand = Random.Range(0, 100);
			if (rand == 0)
			{
				doubleGrow = 2;
				alert.setDouble(true);
			}
		}

		for (int i = this.snakeTail.Count-1; i > 0; i--)
		{
			this.snakeTail[i].position = this.snakeTail[i-1].position;
		}

		this.transform.position = new Vector3(Mathf.Round(this.transform.position.x)+direction.x, Mathf.Round(this.transform.position.y)+this.direction.y, 0.0f);	
	}
	
	private void Grow(int rate)
	{
		for (int i = 0; i < rate; i++)
		{
			Transform newSegment = Instantiate(this.segmentModel);
        		newSegment.position = this.snakeTail[this.snakeTail.Count-1].position;
                                                                             
        		this.snakeTail.Add(newSegment);
		}

		score.UpdateScore(rate);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Apple")
		{
			Grow(this.growRate*doubleGrow);
		}
		else if ((collision.gameObject.tag == "Limit") || (collision.gameObject.tag == "Snake") || (collision.gameObject.tag == "Trap"))
		{
			Destroy(this.gameObject);
			for (int i = 0; i < this.snakeTail.Count; i++)
			{
				Destroy(snakeTail[i].gameObject);
			}
			SceneManager.LoadScene("Score");
		}
	}
}
