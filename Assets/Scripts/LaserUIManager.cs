using UnityEngine;
using CM.Music;

public class LaserUIManager : MusicLevelEditorBeatHandler
{
	[SerializeField]
	private LaserPartUIContainer _laserPartUIContainer;

	[SerializeField]
	private LR_MusicLevelSetup _musicLevelSetup;

	[SerializeField]
	private LR_MusicLevelEditorSpawning _musicLevelEditorSpawning;

	protected override void OnChangeIndex(int currentIndex)
	{
		DestroyUI();

		int preLaserIndex = currentIndex;
		int hitLaserIndex = preLaserIndex - 18;

		CreatePreLaserUI(preLaserIndex);

		CreateHitLaserUI(hitLaserIndex);
	}

	private void DestroyUI()
	{
		foreach (Transform child in transform)
		{
			Destroy(child.gameObject);
		}
	}

	private void CreatePreLaserUI(int preLaserIndex)
	{
		if (preLaserIndex >= 0)
		{
			if (_musicLevelSetup.musicLevel.GetBeat(preLaserIndex).spawnLaser)
			{
				LaserPartUIContainer preLaserUIContainer = Instantiate(_laserPartUIContainer, transform);
				preLaserUIContainer.Initialize(musicLevelEditor, _musicLevelSetup, _musicLevelEditorSpawning);

				preLaserUIContainer.SetLaserType(LaserTypes.PreLaser);
				preLaserUIContainer.Activate();
				preLaserUIContainer.Preset(preLaserIndex);
			}
		}
	}

	private void CreateHitLaserUI(int hitLaserIndex)
	{
		LaserPartUIContainer hitLaserUIContainer = Instantiate(_laserPartUIContainer, transform);
		hitLaserUIContainer.Initialize(musicLevelEditor, _musicLevelSetup, _musicLevelEditorSpawning);

		if (hitLaserIndex >= 0)
		{
			if (_musicLevelSetup.musicLevel.GetBeat(hitLaserIndex).spawnLaser)
			{
				hitLaserUIContainer.SetLaserType(LaserTypes.HitLaser);
				hitLaserUIContainer.Activate();
				hitLaserUIContainer.Preset(hitLaserIndex);
			}
		}
	}
}