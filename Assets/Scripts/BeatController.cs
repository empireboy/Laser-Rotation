﻿using CM.Spawner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RhythmController))]
public class BeatController : MonoBehaviour
{
	[SerializeField]
	private int _beatsBeforeSongStarts = 8;

	[SerializeField]
	private GameObject _beat;

	private RhythmController _rhythmController;
	private AudioSource _audioSource;

	private void Awake()
	{
		_rhythmController = GetComponent<RhythmController>();
	}

	private void Start()
	{
		_rhythmController.BeatEvent += OnBeat;
	}

	private void OnBeat(int beat)
	{
		if (beat == _beatsBeforeSongStarts)
			StartSong();

		int beatIndex = beat - _beatsBeforeSongStarts;
		if (beatIndex >= 0)
		{
			if (_rhythmController.Level.beats[beatIndex].spawnLaser)
			{
				InstantiateBeat(beatIndex);
			}
		}
	}

	public void InstantiateBeat(int beatIndex)
	{
		Transform currentPreLaser = GetComponent<SpawnAroundObject>().Spawn(_beat, _rhythmController.Level.beats[beatIndex].laser.preLaser.angle, _rhythmController.Level.beats[beatIndex].laser.preLaser.radius);
		LaserInitializer laserInitializer = currentPreLaser.GetComponent<LaserInitializer>();
		laserInitializer.index = beatIndex;
		laserInitializer.InitializePreLaser();
	}

	private void StartSong()
	{
		_audioSource = gameObject.AddComponent<AudioSource>();

		if (_audioSource && !_audioSource.isPlaying)
		{
			_audioSource.clip = _rhythmController.Level.audio;
			_audioSource.playOnAwake = false;
			_audioSource.volume = _rhythmController.Level.audioVolume;
			_audioSource.pitch = _rhythmController.Level.audioPitch;
			_audioSource.Play();
		}
	}
}