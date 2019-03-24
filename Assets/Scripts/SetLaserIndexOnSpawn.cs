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
		spawningObject.GetComponent<LaserInitializer>().InitializeLaserPartData(FindObjectOfType<LR_MusicLevelSetup>().musicLevel.GetBeat(GetComponent<LaserInitializer>().index).laser.item.GetLaserPart(LaserTypes.HitLaser));
		spawningObject.GetComponent<LaserInitializer>().ActivateLaser();
	}
}