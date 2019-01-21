using UnityEngine;
using CM.Music;
using CM.Spawner;

[RequireComponent(typeof(LR_MusicLevelSetup))]
[RequireComponent(typeof(LR_SongController))]
public class LR_LaserController : RhythmControllerBeatHandler
{
	public GameObject preLaser;
	public GameObject hitLaser;

	private LR_MusicLevelSetup _laserRotationMusicLevelSetup;
	private LR_SongController _songController;

	protected override void OnAwake()
	{
		_laserRotationMusicLevelSetup = GetComponent<LR_MusicLevelSetup>();
		_songController = GetComponent<LR_SongController>();
	}

	protected override void OnBeat(int currentBeat)
	{
		int beatIndex = currentBeat - _songController.BeatsBeforeSongStarts;
		if (beatIndex >= 0 && _laserRotationMusicLevelSetup.musicLevel.beats[beatIndex].spawnLaser)
		{
			CreateLaser(preLaser, _laserRotationMusicLevelSetup.musicLevel.beats[beatIndex].laser.preLaser, beatIndex, true);
		}
	}

	public void CreateLaser(GameObject laser, LaserPart laserPart, int beatIndex, bool activateLaser)
	{
		Transform currentPreLaser = GetComponent<SpawnAroundObject>().Spawn(laser, laserPart.angle, laserPart.radius);
		LaserInitializer laserInitializer = currentPreLaser.GetComponent<LaserInitializer>();
		laserInitializer.index = beatIndex;

		if (laser == preLaser)
			laserInitializer.InitializeLaserPart(_laserRotationMusicLevelSetup.musicLevel.beats[beatIndex].laser.preLaser);

		if (laser == hitLaser)
			laserInitializer.InitializeLaserPart(_laserRotationMusicLevelSetup.musicLevel.beats[beatIndex].laser.hitLaser);

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