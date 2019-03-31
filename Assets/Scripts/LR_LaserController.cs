using UnityEngine;
using CM.Music;
using CM.Spawner;

[RequireComponent(typeof(LR_MusicLevelSetup))]
public class LR_LaserController : RhythmControllerBeatHandler
{
	public GameObject preLaser;
	public GameObject hitLaser;

	private LR_MusicLevelSetup _musicLevelSetup;

	protected override void OnAwake()
	{
		_musicLevelSetup = GetComponent<LR_MusicLevelSetup>();
	}

	protected override void OnBeat(int currentBeat)
	{
		int beatIndex = currentBeat - rhythmController.Level.BeatsBeforeLevelStarts;
		if (beatIndex >= 0 && _musicLevelSetup.musicLevel.GetBeat(beatIndex).spawnLaser)
		{
			CreateLaser(preLaser, _musicLevelSetup.musicLevel.GetBeat(beatIndex).laser.GetLaserPart(LaserTypes.PreLaser), beatIndex, true);
		}
	}

	public void CreateLaser(GameObject laser, LaserPartData laserPartData, int beatIndex, bool activateLaser)
	{
		Transform currentPreLaser = SpawnAroundObject.Spawn(laser, laserPartData.angle, laserPartData.radius);
		LaserInitializer laserInitializer = currentPreLaser.GetComponent<LaserInitializer>();
		laserInitializer.index = beatIndex;

		if (laser == preLaser)
			laserInitializer.InitializeLaserPartData(_musicLevelSetup.musicLevel.GetBeat(beatIndex).laser.GetLaserPart(LaserTypes.PreLaser));

		if (laser == hitLaser)
			laserInitializer.InitializeLaserPartData(_musicLevelSetup.musicLevel.GetBeat(beatIndex).laser.GetLaserPart(LaserTypes.HitLaser));

		if (activateLaser)
			laserInitializer.ActivateLaser();

		if (!activateLaser)
		{
			if (laser == preLaser)
				laserInitializer.CreateUI(beatIndex, LaserTypes.PreLaser);
			if (laser == hitLaser)
				laserInitializer.CreateUI(beatIndex, LaserTypes.HitLaser);
		}
	}
}