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
	public enum ForceDirections { forward, backward, left, right }
	public ForceDirections forceDirection;
	public Color startColor;
	public Color finalColor;
	public float gravity;
	public float radius;
	public float forceFactor;
	public int angle;
}