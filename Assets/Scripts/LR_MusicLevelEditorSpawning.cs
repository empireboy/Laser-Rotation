using UnityEngine;
using CM.Music;

[RequireComponent(typeof(MusicLevelEditor))]
[RequireComponent(typeof(LR_MusicLevelSetup))]
[RequireComponent(typeof(LR_LaserController))]
public class LR_MusicLevelEditorSpawning : MusicLevelEditorBeatHandler
{
	private MusicLevelEditor _musicLevelEditor;
	private LR_MusicLevelSetup _musicLevelSetup;
	private LR_LaserController _laserController;
	private SongController _songController;
	private RhythmController _rhythmController;

	private int _currentIndex = 0;

	private void Awake()
	{
		_musicLevelEditor = GetComponent<MusicLevelEditor>();
		_musicLevelSetup = GetComponent<LR_MusicLevelSetup>();
		_laserController = GetComponent<LR_LaserController>();
		_songController = FindObjectOfType<SongController>();
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
			LR_Beat beat = new LR_Beat();
			beat.laser.changeItem = true;
			beat.laser.item.preLaser.radius = 5;
			beat.laser.item.preLaser.startColor = Color.green;
			beat.laser.item.hitLaser.radius = 5;
			beat.laser.item.hitLaser.startColor = Color.red;
			beat.laser.item.hitLaser.forceFactor = 2;
			beat.laser.item.hitLaser.forceDirection = LaserPart.ForceDirections.backward;
			CreateNewLaser(beat, _currentIndex);
		}

		if (Input.GetKeyDown(KeyCode.Space) && _currentIndex >= _rhythmController.Level.BeatsBeforeLevelStarts)
		{
			if (_musicLevelEditor.enabled)
			{
				DestroyLasersAndUI();

				GetComponent<RhythmController>().StartLevelAt(_currentIndex);
				_songController.AudioPlayer.PlayAudioAt(_rhythmController.SecondsPerBeat * 0.25f * (_currentIndex - _rhythmController.Level.BeatsBeforeLevelStarts));

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

	protected override void OnChangeIndex(int index)
	{
		_currentIndex = index;
		int songIndex = index - _rhythmController.Level.BeatsBeforeLevelStarts;

		if (index < 0) return;

		_rhythmController.SetCurrentBeat(index);

		DestroyLasersAndUI();

		if (songIndex >= 0)
		{
			_songController.AudioPlayer.PlayAudioAt(SongController.GetSongTime(index), _rhythmController.SecondsPerBeat);
		}

		if (index-18 >= 0)
		{
			if (_musicLevelSetup.musicLevel.GetBeat(index-18).laser.changeItem)
			{
				_laserController.CreateLaser(_laserController.hitLaser, _musicLevelSetup.musicLevel.GetBeat(index-18).laser.GetLaserPart(LaserTypes.HitLaser), index-18, false);
			}
		}

		if (_musicLevelSetup.musicLevel.GetBeat(index).laser.changeItem)
		{
			_laserController.CreateLaser(_laserController.preLaser, _musicLevelSetup.musicLevel.GetBeat(index).laser.GetLaserPart(LaserTypes.PreLaser), index, false);
		}
	}

	public void CreateNewLaser(LR_Beat beat, int index)
	{
		if (index - 18 >= 0)
		{
			_musicLevelSetup.musicLevel.SetBeat(beat, index - 18);
			_laserController.CreateLaser(_laserController.hitLaser, _musicLevelSetup.musicLevel.GetBeat(index-18).laser.GetLaserPart(LaserTypes.HitLaser), index, false);
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