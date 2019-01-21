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
		spawningObject.GetComponent<LaserInitializer>().InitializeLaserPart(FindObjectOfType<LR_MusicLevelSetup>().musicLevel.beats[GetComponent<LaserInitializer>().index].laser.hitLaser);
		spawningObject.GetComponent<LaserInitializer>().ActivateLaser();
	}
}