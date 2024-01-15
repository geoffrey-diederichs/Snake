using UnityEngine;

public class Apple : MonoBehaviour
{
	private Rigidbody2D rb;
	private int lifetime = 3;
	
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
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
