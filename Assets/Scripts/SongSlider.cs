using UnityEngine;
using UnityEngine.UI;
using CM.Music;

[RequireComponent(typeof(Slider))]
public class SongSlider : RhythmControllerBeatHandler
{
	private bool _checkForChangedValue = true;

	private Slider _slider;
	private SongController _songController;
	private MusicLevelEditor _musicLevelEditor;

	protected override void OnAwake()
	{
		_songController = FindObjectOfType<SongController>();
		_musicLevelEditor = FindObjectOfType<MusicLevelEditor>();
		_slider = GetComponent<Slider>();
	}

	protected override void OnStart()
	{
		_slider.onValueChanged.AddListener(OnValueChanged);
		OnAudioInitialized(_songController.AudioPlayer.AudioSource);
	}

	private void OnValueChanged(float value)
	{
		if (!_checkForChangedValue)
		{
			_checkForChangedValue = true;
			return;
		}

		int index = Mathf.RoundToInt(value);
		_musicLevelEditor.UpdateIndex(index);
	}

	private void OnAudioInitialized(AudioSource audioSource)
	{
		_slider.maxValue = rhythmController.TotalBeats;
	}

	protected override void OnBeat(int beatIndex)
	{
		_slider.value = beatIndex;
		_checkForChangedValue = false;
	}
}