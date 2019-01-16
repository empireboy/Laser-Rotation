using UnityEngine;

[System.Serializable]
public struct Laser
{
	public LaserPart preLaser;
	public LaserPart hitLaser; 
}

[System.Serializable]
public struct LaserPart
{
	public Vector2 force;
	public Color startColor;
	public Color finalColor;
	public float gravity;
	public float lifetime;
}