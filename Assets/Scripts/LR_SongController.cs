using UnityEngine;
using CM.Music;

[RequireComponent(typeof(LR_MusicLevelSetup))]
public class LR_SongController : RhythmControllerBeatHandler
{
	private AudioSource _audio;
	public AudioSource Audio { get => _audio; }

	[SerializeField] private int _beatsBeforeSongStarts = 8;
	public int BeatsBeforeSongStarts { get => _beatsBeforeSongStarts; }

	protected override void OnBeat(int currentBeat)
	{
		if (currentBeat == _beatsBeforeSongStarts)
		{
			_audio = gameObject.AddComponent<AudioSource>();
			if (_audio && !_audio.isPlaying)
			{
				LR_MusicLevelSetup laserRotationMusicLevelSetup = GetComponent<LR_MusicLevelSetup>();
				_audio.clip = laserRotationMusicLevelSetup.musicLevel.audio;
				_audio.volume = laserRotationMusicLevelSetup.musicLevel.audioVolume;
				_audio.pitch = laserRotationMusicLevelSetup.musicLevel.audioPitch;
				_audio.playOnAwake = false;
				_audio.Play();
				Release();
			}
			else
			{
				Release();
			}
		}
	}
}