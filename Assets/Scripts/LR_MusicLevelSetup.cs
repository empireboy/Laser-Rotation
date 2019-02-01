using UnityEngine;
using CM.Music;

public class LR_MusicLevelSetup : MonoBehaviour
{
	public LR_MusicLevel musicLevel;

	private void Awake()
	{
		GetComponent<RhythmController>().SetMusicLevel(musicLevel);
		GetComponent<LR_SongController>().SetAudio(musicLevel);
	}

	private void Start()
	{
		if (musicLevel.GetBeatCount() <= 0)
		{
			ResetBeats();
		}
	}

	public void ResetBeats()
	{
		musicLevel.ClearBeats();

		int totalBeats = Mathf.FloorToInt(FindObjectOfType<RhythmController>().TotalBeats) + FindObjectOfType<LR_SongController>().BeatsBeforeSongStarts;
		for (int i = 0; i < totalBeats; i++)
		{
			musicLevel.AddBeat(new Beat());
		}
	}
}