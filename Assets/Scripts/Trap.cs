using UnityEngine;

public class Trap : MonoBehaviour
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
	}
}
