using UnityEngine;

public class LaserRotationMusicLevelSetup : MonoBehaviour
{
	public LaserRotationMusicLevel musicLevel;

	private void Awake()
	{
		GetComponent<CM.Music.RhythmController>().SetMusicLevel(musicLevel);
	}
}