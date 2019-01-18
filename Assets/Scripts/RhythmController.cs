using UnityEngine;

public class RhythmController : MonoBehaviour
{
	[SerializeField]
	private Level _level;
	public Level Level { get => _level; }

	public delegate void BeatHandler(int beat);
	public event BeatHandler BeatEvent;

	private int _currentBeat = 0;
	public int CurrentBeat { get => _currentBeat; }

	private float _secondsPerBeat;
	public float SecondsPerBeat { get => _secondsPerBeat; }

	private void Awake()
	{
		_secondsPerBeat = 60f / _level.bpm;
		Camera.main.orthographicSize = _level.cameraSize;
	}

	private void Start()
	{
		InvokeRepeating("NextBeat", 0, _secondsPerBeat * 0.25f);
	}

	private void NextBeat()
	{
		BeatEvent?.Invoke(_currentBeat);

		_currentBeat++;
	}
}