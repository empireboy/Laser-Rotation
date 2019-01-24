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
	private RhythmController _rhythmController;

	private int _currentIndex = 0;

	private void Awake()
	{
		_musicLevelEditor = GetComponent<MusicLevelEditor>();
		_musicLevelSetup = GetComponent<LR_MusicLevelSetup>();
		_laserController = GetComponent<LR_LaserController>();
		_songController = GetComponent<LR_SongController>();
		_rhythmController = FindObjectOfType<RhythmController>();
	}

	private void Start()
	{
		_musicLevelEditor.ChangeIndexEvent += OnChangeIndex;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			Beat beat = new Beat
			{
				spawnLaser = true
			};
			beat.laser.preLaser.radius = 5;
			beat.laser.preLaser.startColor = Color.green;
			beat.laser.hitLaser.radius = 5;
			beat.laser.hitLaser.startColor = Color.red;
			CreateNewLaser(beat, _currentIndex);
		}

		if (Input.GetKeyDown(KeyCode.Space) && _currentIndex >= _songController.BeatsBeforeSongStarts)
		{
			if (_musicLevelEditor.enabled)
			{
				DestroyLasersAndUI();

				GetComponent<RhythmController>().StartLevelAt(_currentIndex);
				_songController.AudioPlayer.PlayAudioAt(GetComponent<RhythmController>().SecondsPerBeat * 0.25f * (_currentIndex - _songController.BeatsBeforeSongStarts));

				_musicLevelEditor.enabled = false;
			}
			else
			{
				_musicLevelEditor.UpdateIndex();
				GetComponent<RhythmController>().StopLevel();
				_songController.AudioPlayer.Stop();

				_musicLevelEditor.enabled = true;
			}
		}
	}

	private void OnChangeIndex(int index)
	{
		_currentIndex = index;
		Debug.Log(index);
		int songIndex = index - _songController.BeatsBeforeSongStarts;

		if (index < 0) return;

		DestroyLasersAndUI();

		if (songIndex >= 0)
		{
			_songController.AudioPlayer.PlayAudioAt(_rhythmController.SecondsPerBeat * 0.25f * songIndex, _rhythmController.SecondsPerBeat);
		}

		if (index-18 >= 0)
		{
			if (_musicLevelSetup.musicLevel.beats[index-18].spawnLaser)
			{
				_laserController.CreateLaser(_laserController.hitLaser, _musicLevelSetup.musicLevel.beats[index-18].laser.hitLaser, index-18, false);
			}
		}

		if (_musicLevelSetup.musicLevel.beats[index].spawnLaser)
		{
			_laserController.CreateLaser(_laserController.preLaser, _musicLevelSetup.musicLevel.beats[index].laser.preLaser, index, false);
		}
	}

	public void CreateNewLaser(Beat beat, int index)
	{
		if (index - 18 >= 0)
		{
			_musicLevelSetup.musicLevel.beats[index - 18] = beat;
			_laserController.CreateLaser(_laserController.hitLaser, _musicLevelSetup.musicLevel.beats[index - 18].laser.hitLaser, index, false);
			_musicLevelEditor.UpdateIndex();
		}
	}

	private void DestroyLasersAndUI()
	{
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
	}
}