using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CM/LaserRotation/New Level", fileName = "NewLevel.asset")]
public class Level : ScriptableObject
{
	public int bpm;
	public AudioClip audio;
	public float audioVolume = 1;
	public float audioPitch = 1;
	public float cameraSize = 5;
	public List<Beat> beats;
}