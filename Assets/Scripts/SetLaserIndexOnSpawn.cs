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
		spawningObject.GetComponent<LaserInitializer>().InitializeLaserPart(FindObjectOfType<LR_MusicLevelSetup>().musicLevel.GetLaserPart(LaserTypes.HitLaser, GetComponent<LaserInitializer>().index));
		spawningObject.GetComponent<LaserInitializer>().ActivateLaser();
	}
}