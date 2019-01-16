using CM.Spawner;
using UnityEngine;

public class SetLaserIndexOnSpawn : MonoBehaviour
{
	private void Start()
	{
		GetComponent<SpawnAtCurrentTransform>().SpawnEvent += OnSpawn;
	}

	private void OnSpawn(Transform spawningObject)
	{
		spawningObject.GetComponent<LaserInitializer>().index = GetComponent<LaserInitializer>().index;
		spawningObject.GetComponent<LaserInitializer>().InitializeHitLaser();
	}
}