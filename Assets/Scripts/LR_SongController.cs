using UnityEngine;
using CM.Music;
using System.Collections;

[RequireComponent(typeof(LR_MusicLevelSetup))]
public class LR_SongController : RhythmControllerBeatHandler
{
	private AudioSource _audio;
	public AudioSource Audio { get => _audio; }

	[SerializeField] private int _beatsBeforeSongStarts = 8;
	public int BeatsBeforeSongStarts { get => _beatsBeforeSongStarts; }

	protected override void OnStart()
	{
		LR_MusicLevelSetup laserRotationMusicLevelSetup = GetComponent<LR_MusicLevelSetup>();
		_audio = gameObject.AddComponent<AudioSource>();
		_audio.clip = laserRotationMusicLevelSetup.musicLevel.audio;
		_audio.volume = laserRotationMusicLevelSetup.musicLevel.audioVolume;
		_audio.pitch = laserRotationMusicLevelSetup.musicLevel.audioPitch;
		_audio.playOnAwake = false;
	}

	protected override void OnBeat(int currentBeat)
	{
		if (currentBeat == _beatsBeforeSongStarts)
		{
			if (_audio && !_audio.isPlaying)
			{
				_audio.Play();
			}
			Release();
		}
	}

	public void PlayAudioAt(float audioTime, float time)
	{
		_audio.time = audioTime;
		_audio.Play();
		StartCoroutine(PlayAudioAtRoutine(time));
	}

	public void StopAudio()
	{
		_audio.Stop();
	}

	private IEnumerator PlayAudioAtRoutine(float time)
	{
		yield return new WaitForSeconds(time);
		StopAudio();
	}
}