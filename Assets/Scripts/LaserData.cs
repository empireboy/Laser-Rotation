using UnityEngine;

[System.Serializable]
public struct LaserData
{
	public LaserPartData preLaser;
	public LaserPartData hitLaser;

	public void SetLaserPart(LaserPartData laserPart, LaserTypes laserType)
	{
		switch (laserType)
		{
			case LaserTypes.PreLaser:
				preLaser = laserPart;
				LockProperties(laserPart, laserType);
				break;
			case LaserTypes.HitLaser:
				hitLaser = laserPart;
				LockProperties(laserPart, laserType);
				break;
		}
	}

	public LaserPartData GetLaserPart(LaserTypes laserType)
	{
		LaserPartData laserPart = new LaserPartData();

		switch (laserType)
		{
			case LaserTypes.PreLaser:
				laserPart = preLaser;
				break;
			case LaserTypes.HitLaser:
				laserPart = hitLaser;
				break;
		}

		return laserPart;
	}

	public void LockProperties(LaserPartData laserPart, LaserTypes laserType)
	{
		switch (laserType)
		{
			case LaserTypes.PreLaser:
				hitLaser.angle = laserPart.angle;
				hitLaser.radius = laserPart.radius;
				break;
			case LaserTypes.HitLaser:
				preLaser.angle = laserPart.angle;
				preLaser.radius = laserPart.radius;
				break;
		}
	}
}

[System.Serializable]
public struct LaserPartData
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