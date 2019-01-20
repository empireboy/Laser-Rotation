using UnityEngine;
using CM.Music;
using CM.Spawner;

[RequireComponent(typeof(LR_MusicLevelSetup))]
[RequireComponent(typeof(LR_SongController))]
public class LR_LaserController : RhythmControllerBeatHandler
{
	[SerializeField] private GameObject _laser;

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
			CreateLaser(_laserRotationMusicLevelSetup.musicLevel.beats[beatIndex].laser, beatIndex);
		}
	}

	public void CreateLaser(Laser laser, int beatIndex)
	{
		Transform currentPreLaser = GetComponent<SpawnAroundObject>().Spawn(_laser, laser.preLaser.angle, laser.preLaser.radius);
		LaserInitializer laserInitializer = currentPreLaser.GetComponent<LaserInitializer>();
		laserInitializer.index = beatIndex;
		laserInitializer.InitializeLaserPart(_laserRotationMusicLevelSetup.musicLevel.beats[beatIndex].laser.preLaser);
	}
}