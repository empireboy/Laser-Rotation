using UnityEngine;
using UnityEngine.UI;
using CM.Music;

[RequireComponent(typeof(Slider))]
public class SongSlider : MonoBehaviour
{
	private bool _checkForChangedValue = true;

	private void Awake()
	{
		GetComponent<Slider>().onValueChanged.AddListener(OnValueChanged);
	}

	private void Start()
	{
		OnAudioInitialized(FindObjectOfType<LR_SongController>().AudioPlayer.AudioSource);
		FindObjectOfType<RhythmController>().BeatEvent += OnBeat;
	}

	private void OnValueChanged(float value)
	{
		if (!_checkForChangedValue)
		{
			_checkForChangedValue = true;
			return;
		}

		int index = Mathf.RoundToInt(value);
		FindObjectOfType<MusicLevelEditor>().UpdateIndex(index);
	}

	private void OnAudioInitialized(AudioSource audioSource)
	{
		Slider slider = GetComponent<Slider>();
		slider.maxValue = FindObjectOfType<RhythmController>().TotalBeats;
	}

	private void OnBeat(int beatIndex)
	{
		Slider slider = GetComponent<Slider>();
		slider.value = beatIndex;
		_checkForChangedValue = false;
	}
}