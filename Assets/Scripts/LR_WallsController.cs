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

		// Get latest wallsData that it can find
		bool foundWallsData = false;
		int wallsBeatIndex = currentBeat;
		while (!foundWallsData && wallsBeatIndex >= 0)
		{
			if (_musicLevelSetup.musicLevel.GetBeat(wallsBeatIndex).changeWalls)
			{
				foundWallsData = true;
			}
			else
			{
				wallsBeatIndex--;
			}
		}

		if (wallsBeatIndex >= 0)
		{
			ChangeWalls(_musicLevelSetup.musicLevel.GetBeat(wallsBeatIndex).walls, wallsBeatIndex);
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