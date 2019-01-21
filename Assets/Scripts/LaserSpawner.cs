using UnityEngine;
using CM.Spawner;

public class LaserSpawner : MonoBehaviour
{
	public int spawnTime = 1;

	public void SetNextSpawn()
	{
		GetComponent<SpawnAtCurrentTransform>().Spawn(spawnTime);
		GetComponent<SpawnAtCurrentTransform>().SpawnEvent += OnSpawn;
	}

	private void OnSpawn(Transform spawningObject)
	{
		GetComponent<SpawnAtCurrentTransform>().SpawnEvent -= OnSpawn;
		Destroy(gameObject);
	}
}