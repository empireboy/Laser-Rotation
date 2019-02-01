using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CM.Music;

public class BeatDisplay : MonoBehaviour
{
	[SerializeField]
	private List<Transform> _beatTransforms;

	[SerializeField]
	private GameObject _display;

	private RhythmController _rhythmController;

	private void Awake()
	{
		_rhythmController = FindObjectOfType<RhythmController>();
	}

	private void Start()
	{
		_rhythmController.BeatEvent += OnBeat;

		_display = Instantiate(_display);
		SetDisplay(0);
	}

	private void OnBeat(int beatIndex)
	{
		if (beatIndex - FindObjectOfType<LR_SongController>().BeatsBeforeSongStarts < 0)
		{
			SetDisplay(0);
			return;
		}

		beatIndex = beatIndex % 4;

		SetDisplay(beatIndex);
	}

	private void SetDisplay(int beatIndex)
	{
		_display.transform.parent = _beatTransforms[beatIndex];
		_display.transform.localPosition = Vector3.zero;
	}
}