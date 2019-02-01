using UnityEngine;
using CM.Music;

public class LR_SongController : RhythmControllerBeatHandler
{
	private AudioPlayer _audioPlayer;
	public AudioPlayer AudioPlayer { get => _audioPlayer; }

	[SerializeField] private int _beatsBeforeSongStarts = 8;
	public int BeatsBeforeSongStarts { get => _beatsBeforeSongStarts; }

	public bool autoPlay = true;

	protected override void OnBeat(int currentBeat)
	{
		if (currentBeat == _beatsBeforeSongStarts)
		{
			if (_audioPlayer.AudioSource && !_audioPlayer.IsPlaying && autoPlay)
			{
				_audioPlayer.Play();
			}
			Release();
		}
	}

	public void SetAudio(IMusicLevel musicLevel)
	{
		if (!_audioPlayer)
			_audioPlayer = gameObject.AddComponent<AudioPlayer>();

		_audioPlayer.SetAudio(musicLevel.AudioData);
	}

	public float GetSongTime(float secondsPerBeat, int beatIndex)
	{
		return secondsPerBeat * 0.25f * (beatIndex - _beatsBeforeSongStarts);
	}
}