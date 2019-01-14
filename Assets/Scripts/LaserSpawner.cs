using UnityEngine;
using CM.Spawner;

public class LaserSpawner : MonoBehaviour
{
	private void Start()
	{
		GetComponent<SpawnAtCurrentTransform>().Spawn(1);
	}
}