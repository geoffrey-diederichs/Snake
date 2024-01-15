using UnityEngine;

public class ObstacleHor : MonoBehaviour
{
	private Vector2 direction;

	private void Start()
	{
		this.direction = Vector2.right;
	}

	private void FixedUpdate()
	{
		if (this.transform.position.x > 17)
		{
			this.direction = Vector2.left;
		}
		else if (this.transform.position.x < -17)
		{
			this.direction = Vector2.right;
		}

		this.transform.position = new Vector3(Mathf.Round(this.transform.position.x)+direction.x, Mathf.Round(this.transform.position.y)+this.direction.y, 0.0f);
	}	
}
