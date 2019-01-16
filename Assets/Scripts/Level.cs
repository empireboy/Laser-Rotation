using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CM/LaserRotation/New Level", fileName = "NewLevel.asset")]
public class Level : ScriptableObject
{
	public int bpm;
	public AudioClip audio;
	public List<Beat> lasers;
}