using UnityEngine;
using CM.Spawner;
using System.Collections.Generic;

public class RhythmController : MonoBehaviour
{
	public int bpm;
	public float secondsToReachTarget = 1f;
	public float slownessFactor = 1;
	public float delay = 0;

	private float _secondsPerBeat;
	private int _currentBeat = 0;
	private int _circleCounter = 0;

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
		InvokeRepeating("NextBeat", secondsToReachTarget + delay, _secondsPerBeat * slownessFactor);
	}

	private void NextBeat()
	{
		/*if (_currentCircleCounter <= 0)
		{
			for (int i = 0; i < 4; i++)
			{
				bool randomBool = (Random.Range(0, 2) <= 0.5) ? true : false;
				_circles[i].gameObject.SetActive(randomBool);
			}
			if (
				_circles[0].gameObject.activeSelf &&
				_circles[1].gameObject.activeSelf &&
				_circles[2].gameObject.activeSelf &&
				_circles[3].gameObject.activeSelf
			)
			{
				_circles[0].gameObject.SetActive(false);
			}
			_currentCircleCounter = circleCounter;
		}
		else if (_currentCircleCounter >= 2)
		{
			GetComponent<SpawnAroundObject>().Spawn(Random.Range(0, 360), 5);
		}*/

		if (_laserArray[_currentBeat] != -1 && _laserArray[_currentBeat] != 999)
		{
			GetComponent<SpawnAroundObject>().Spawn(_laserArray[_currentBeat], 5);
		}

		if (_laserArray[_currentBeat] == 999)
		{
			for (int i = 0; i < 4; i++)
			{
				_circles[i].gameObject.SetActive(_circleArray[_circleCounter].circleActive[i]);
			}
		}

		_currentBeat++;
	}

	[System.Serializable]
	public struct CircleStruct
	{
		public bool[] circleActive;
	}
}