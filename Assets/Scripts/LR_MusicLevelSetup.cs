using UnityEngine;

public class LR_MusicLevelSetup : MonoBehaviour
{
	public LR_MusicLevel musicLevel;

	private void Awake()
	{
		GetComponent<CM.Music.RhythmController>().SetMusicLevel(musicLevel);
	}
}