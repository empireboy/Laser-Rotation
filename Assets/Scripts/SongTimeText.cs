using UnityEngine;
using UnityEngine.UI;
using CM.Music;

[RequireComponent(typeof(Text))]
public class SongTimeText : MonoBehaviour
{
	[SerializeField]
	private string _timeText = "Time:";

	private Text _text;
	private LR_SongController _songController;
	private RhythmController _rhythmController;

	private void Awake()
	{
		_text = GetComponent<Text>();
		_songController = FindObjectOfType<LR_SongController>();
		_rhythmController = FindObjectOfType<RhythmController>();
	}

	private void Start()
	{
		_rhythmController.BeatEvent += OnBeat;
	}

	private void OnBeat(int beatIndex)
	{
		float value = Mathf.Round(_songController.GetSongTime(_rhythmController.SecondsPerBeat, beatIndex) * 100f) / 100f;
		_text.text = _timeText + " " + value;
	}
}