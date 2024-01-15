using UnityEngine;

public class Apple : MonoBehaviour
{
	private int lifetime = 3;
	
	private void Awake()
	{
	}

	private void Start()
	{
		Destroy(this.gameObject, this.lifetime);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Snake")
		{
			Destroy(this.gameObject);
		}
	}
}	
