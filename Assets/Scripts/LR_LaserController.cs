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
		if (beatIndex >= 0 && _musicLevelSetup.musicLevel.GetBeat(beatIndex).laser.changeItem)
		{
			CreateLaser(preLaser, _musicLevelSetup.musicLevel.GetBeat(beatIndex).laser.GetLaserPart(LaserTypes.PreLaser), beatIndex, true);
		}
	}

	public void CreateLaser(GameObject laser, LaserPart laserPart, int beatIndex, bool activateLaser)
	{
		Transform currentPreLaser = SpawnAroundObject.Spawn(laser, laserPart.angle, laserPart.radius);
		LaserInitializer laserInitializer = currentPreLaser.GetComponent<LaserInitializer>();
		laserInitializer.index = beatIndex;

		if (laser == preLaser)
			laserInitializer.InitializeLaserPart(_musicLevelSetup.musicLevel.GetBeat(beatIndex).laser.GetLaserPart(LaserTypes.PreLaser));

		if (laser == hitLaser)
			laserInitializer.InitializeLaserPart(_musicLevelSetup.musicLevel.GetBeat(beatIndex).laser.GetLaserPart(LaserTypes.HitLaser));

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