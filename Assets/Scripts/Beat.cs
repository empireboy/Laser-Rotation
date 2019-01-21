using UnityEngine;

[System.Serializable]
public class Beat
{
	[Header("Laser")]
	public bool spawnLaser;
	public Laser laser;

	[Header("Walls")]
	public bool changeWalls;
	public Walls wall;
}