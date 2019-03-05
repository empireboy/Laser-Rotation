using CM.Music;

[System.Serializable]
public class BeatItemLaser : BeatItem<Laser>
{
	#region BeatItemLaser Set
	public void SetLaser(Laser laser)
	{
		item = laser;
	}

	public void SetLaserPart(LaserPart laserPart, LaserTypes laserType)
	{
		switch (laserType)
		{
			case LaserTypes.PreLaser:
				item.preLaser = laserPart;
				LockProperties(laserPart, laserType);
				break;
			case LaserTypes.HitLaser:
				item.hitLaser = laserPart;
				LockProperties(laserPart, laserType);
				break;
		}
	}
	#endregion

	#region BeatItemLaser Get
	public LaserPart GetLaserPart(LaserTypes laserType)
	{
		switch (laserType)
		{
			case LaserTypes.PreLaser:
				return item.preLaser;
			case LaserTypes.HitLaser:
				return item.hitLaser;
		}

		return default;
	}

	public Laser GetLaser()
	{
		return item;
	}
	#endregion

	public void LockProperties(LaserPart laserPart, LaserTypes laserType)
	{
		switch (laserType)
		{
			case LaserTypes.PreLaser:
				item.hitLaser.angle = laserPart.angle;
				item.hitLaser.radius = laserPart.radius;
				break;
			case LaserTypes.HitLaser:
				item.preLaser.angle = laserPart.angle;
				item.preLaser.radius = laserPart.radius;
				break;
		}
	}
}