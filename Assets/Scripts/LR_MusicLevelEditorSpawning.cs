using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CM.Music;

[RequireComponent(typeof(MusicLevelEditor))]
[RequireComponent(typeof(LR_MusicLevelSetup))]
[RequireComponent(typeof(LR_LaserController))]
public class LR_MusicLevelEditorSpawning : MonoBehaviour
{
	private MusicLevelEditor _musicLevelEditor;
	private LR_MusicLevelSetup _musicLevelSetup;
	private LR_LaserController _laserController;
	private LR_SongController _songController;

	private int _currentIndex = 0;

	private void Awake()
	{
		_musicLevelEditor = GetComponent<MusicLevelEditor>();
		_musicLevelSetup = GetComponent<LR_MusicLevelSetup>();
		_laserController = GetComponent<LR_LaserController>();
		_songController = GetComponent<LR_SongController>();
	}

	private void Start()
	{
		_musicLevelEditor.ChangeIndexEvent += OnChangeIndex;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Beat beat = new Beat
			{
				spawnLaser = true
			};
			beat.laser.preLaser.radius = 5;
			beat.laser.preLaser.startColor = Color.blue;
			beat.laser.hitLaser.radius = 5;
			beat.laser.hitLaser.startColor = Color.red;
			CreateNewLaser(beat, _currentIndex);
		}
	}

	private void OnChangeIndex(int index)
	{
		_currentIndex = index;
		Debug.Log(index);
		int songIndex = index - GetComponent<LR_SongController>().BeatsBeforeSongStarts;

		if (index < 0) return;

		GameObject[] lasers = GameObject.FindGameObjectsWithTag("Laser");
		foreach (GameObject laser in lasers)
		{
			Destroy(laser);
		}

		GameObject[] lasersUI = GameObject.FindGameObjectsWithTag("LaserUI");
		foreach (GameObject laserUI in lasersUI)
		{
			Destroy(laserUI);
		}

		if (songIndex >= 0)
		{
			_songController.PlayAudioAt(GetComponent<RhythmController>().SecondsPerBeat / 2 * songIndex, 0.25f);
		}

		if (index-8 >= 0)
		{
			if (_musicLevelSetup.musicLevel.beats[index-8].spawnLaser)
			{
				_laserController.CreateLaser(_laserController.hitLaser, _musicLevelSetup.musicLevel.beats[index-8].laser.hitLaser, index-8, false);
			}
		}

		if (_musicLevelSetup.musicLevel.beats[index].spawnLaser)
		{
			_laserController.CreateLaser(_laserController.preLaser, _musicLevelSetup.musicLevel.beats[index].laser.preLaser, index, false);
		}
	}

	private void CreateNewLaser(Beat beat, int index)
	{
		if (index - 8 >= 0)
		{
			_musicLevelSetup.musicLevel.beats[index - 8] = beat;
			_laserController.CreateLaser(_laserController.hitLaser, _musicLevelSetup.musicLevel.beats[index - 8].laser.hitLaser, index, false);
			_musicLevelEditor.UpdateIndex();
		}
	}
}