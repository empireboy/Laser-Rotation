using UnityEngine;
using System.Collections.Generic;

public class RhythmController : MonoBehaviour
{
	[SerializeField]
	private Level _level;
	public Level Level { get => _level; }
	//public float secondsToReachTarget = 1f;
	//public float slownessFactor = 1;

	public delegate void BeatHandler(int beat);
	public event BeatHandler BeatEvent;

	private int _currentBeat = 0;
	public int CurrentBeat { get => _currentBeat; }

	private float _secondsPerBeat;
	public float SecondsPerBeat { get => _secondsPerBeat; }

	//private int _circleCounter = 0;

	[SerializeField]
	private List<Transform> _circles;

	[SerializeField]
	private List<int> _laserArray;

	[SerializeField]
	private List<CircleStruct> _circleArray;

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
		/*if (_laserArray[_currentBeat] != -1 && _laserArray[_currentBeat] != 999)
		{
			GetComponent<SpawnAroundObject>().Spawn(_laserArray[_currentBeat], 5);
		}

		if (_laserArray[_currentBeat] == 999)
		{
			for (int i = 0; i < 4; i++)
			{
				_circles[i].gameObject.SetActive(_circleArray[_circleCounter].circleActive[i]);
			}
		}*/

		BeatEvent?.Invoke(_currentBeat);

		_currentBeat++;
	}

	[System.Serializable]
	public struct CircleStruct
	{
		public bool[] circleActive;
	}
}