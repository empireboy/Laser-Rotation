using UnityEngine;
using UnityEngine.UI;
using CM.Music;

[RequireComponent(typeof(Text))]
public class SongTimeText : RhythmControllerBeatHandler
{
	[SerializeField]
	private string _timeText = "Time:";

	private Text _text;

	protected override void OnAwake()
	{
		_text = GetComponent<Text>();
	}

	protected override void OnBeat(int beatIndex)
	{
		float value = Mathf.Round(SongController.GetSongTime(beatIndex) * 100f) / 100f;
		_text.text = _timeText + " " + value;
	}
}