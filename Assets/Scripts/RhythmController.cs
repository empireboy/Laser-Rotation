using UnityEngine;
using CM.Spawner;
using System.Collections.Generic;

public class RhythmController : MonoBehaviour
{
	public int bpm;

	//public float secondsToReachTarget = 1f;
	//public float slownessFactor = 1;

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
		_secondsPerBeat = 60f / bpm;
	}

	private void Start()
	{
		InvokeRepeating("NextBeat", 0, SecondsPerBeat * 0.25f);
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

		_currentBeat++;
	}

	[System.Serializable]
	public struct CircleStruct
	{
		public bool[] circleActive;
	}
}