using System.Collections.Generic;
using UnityEngine;
using CM.Music;

public class BeatDisplay : RhythmControllerBeatHandler
{
	[SerializeField]
	private List<Transform> _beatTransforms;

	[SerializeField]
	private GameObject _display;

	protected override void OnStart()
	{
		_display = Instantiate(_display);
		SetDisplay(0);
	}

	protected override void OnBeat(int beatIndex)
	{
		if (beatIndex - rhythmController.Level.BeatsBeforeLevelStarts < 0)
		{
			SetDisplay(0);
			return;
		}

		beatIndex = beatIndex % 4;

		SetDisplay(beatIndex);
	}

	private void SetDisplay(int beatIndex)
	{
		_display.transform.SetParent(_beatTransforms[beatIndex]);
		_display.transform.localPosition = Vector3.zero;
	}
}