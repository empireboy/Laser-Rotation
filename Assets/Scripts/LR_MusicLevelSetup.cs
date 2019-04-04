using UnityEngine;
using CM.Music;

[RequireComponent(typeof(RhythmController))]
public class LR_MusicLevelSetup : MonoBehaviour
{
	public LR_MusicLevel musicLevel;

	private RhythmController _rhythmController;

	private void Awake()
	{
		_rhythmController = GetComponent<RhythmController>();
	}

	private void Start()
	{
		_rhythmController.SetMusicLevel(musicLevel);
		GetComponent<SongController>().SetAudio(musicLevel);

		if (musicLevel.GetBeatCount() <= 0)
		{
			ResetBeats();
		}
	}

	public void ResetBeats()
	{
		musicLevel.ClearBeats();

		int totalBeats = Mathf.FloorToInt(_rhythmController.TotalBeats) + _rhythmController.Level.BeatsBeforeLevelStarts;
		for (int i = 0; i < totalBeats; i++)
		{
			musicLevel.AddBeat(new LR_Beat());
		}

		WallsData walls = new WallsData()
		{
			back = true,
			front = false,
			left = true,
			right = true
		};

		musicLevel.GetBeat(0).changeWalls = true;
		musicLevel.GetBeat(0).walls = walls;
	}
}