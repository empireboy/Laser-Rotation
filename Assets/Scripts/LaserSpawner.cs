using UnityEngine;
using CM.Spawner;

public class LaserSpawner : MonoBehaviour
{
	private void Awake()
	{
		GetComponent<SpawnAtCurrentTransform>().Spawn(1);
		GetComponent<SpawnAtCurrentTransform>().spawnEvent += OnSpawn;
	}

	private void OnSpawn()
	{
		Destroy(gameObject);
	}
}