using CM.Music;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LR_MusicLevelSetup))]
public class LR_WallsController : RhythmControllerBeatHandler
{
	[SerializeField]
	private Transform[] _walls;

	private LR_MusicLevelSetup _musicLevelSetup;

	protected override void OnAwake()
	{
		_musicLevelSetup = GetComponent<LR_MusicLevelSetup>();
	}

	protected override void OnBeat(int currentBeat)
	{
		int beatIndex = currentBeat - rhythmController.Level.BeatsBeforeLevelStarts;
		if (beatIndex >= 0 && _musicLevelSetup.musicLevel.GetBeat(beatIndex).changeWalls)
		{
			ChangeWalls(_musicLevelSetup.musicLevel.GetBeat(beatIndex).walls, beatIndex);
		}
	}

	public void ChangeWalls(WallsData wallsData, int beatIndex)
	{
		_walls[0].gameObject.SetActive(wallsData.front);
		_walls[1].gameObject.SetActive(wallsData.back);
		_walls[2].gameObject.SetActive(wallsData.left);
		_walls[3].gameObject.SetActive(wallsData.right);
	}
}