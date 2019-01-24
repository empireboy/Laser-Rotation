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
			if (_audioPlayer.audioSource && !_audioPlayer.IsPlaying && autoPlay)
			{
				_audioPlayer.Play();
			}
			Release();
		}
	}

	public void SetAudio(IMusicLevel audio)
	{
		if (!_audioPlayer)
			_audioPlayer = gameObject.AddComponent<AudioPlayer>();

		if (!_audioPlayer.audioSource)
			_audioPlayer.audioSource = gameObject.AddComponent<AudioSource>();

		AudioData audioData = new AudioData
		{
			clip = audio.GetAudioClip(),
			volume = audio.GetAudioVolume(),
			pitch = audio.GetAudioPitch(),
			playOnAwake = false
		};

		_audioPlayer.SetAudio(audioData);
	}
}