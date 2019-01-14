using UnityEngine;
using CM.Spawner;

public class LaserSpawner : MonoBehaviour
{
	public int spawnTime = 1;

	private void Awake()
	{
		GetComponent<SpawnAtCurrentTransform>().Spawn(spawnTime);
		GetComponent<SpawnAtCurrentTransform>().spawnEvent += OnSpawn;
	}

	private void OnSpawn()
	{
		GetComponent<SpawnAtCurrentTransform>().spawnEvent -= OnSpawn;
		Destroy(gameObject);
	}
}