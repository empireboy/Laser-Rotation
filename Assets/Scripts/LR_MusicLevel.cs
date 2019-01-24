using CM.Music;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LaserRotation/New Music Level", fileName = "NewMusicLevel.asset")]
public class LR_MusicLevel : ScriptableObject, IMusicLevel
{
	public int bpm;
	public AudioClip audio;
	public float audioVolume = 1;
	public float audioPitch = 1;
	public float cameraSize = 5;

	public int GetBpm()
	{
		return bpm;
	}

	public AudioClip GetAudioClip()
	{
		return audio;
	}

	public float GetAudioVolume()
	{
		return audioVolume;
	}

	public float GetAudioPitch()
	{
		return audioPitch;
	}

	public List<Beat> beats;
}