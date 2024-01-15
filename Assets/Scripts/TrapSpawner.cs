using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
	public Trap trapModel;
	private int spawnRate = 3;
	private int spawnAmount = 5;
	private int xLimit = 21;
	private int yLimit = 10;

	private void Start()
	{
		InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
	}

	private void Spawn()
	{
		for (int i = 0; i < this.spawnAmount; i++)
		{
			int spawnX = Random.Range(-1*this.xLimit, this.xLimit);
			int spawnY = Random.Range(-1*this.yLimit, this.yLimit);

			Vector3 spawnPoint = this.transform.position + new Vector3(spawnX, spawnY, 0);
			Trap trap = Instantiate(trapModel, spawnPoint, new Quaternion());
		}
	}
}
