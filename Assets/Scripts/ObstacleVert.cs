using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleVert : MonoBehaviour
{
	private Vector2 direction;

	private void Start()
	{
		this.direction = Vector2.up;
	}

	private void FixedUpdate()
	{
		if (this.transform.position.y > 7)
		{
			this.direction = Vector2.down;
		}
		else if (this.transform.position.y < -7)
		{
			this.direction = Vector2.up;
		}

		this.transform.position = new Vector3(Mathf.Round(this.transform.position.x)+direction.x, Mathf.Round(this.transform.position.y)+this.direction.y, 0.0f);
	}
}
