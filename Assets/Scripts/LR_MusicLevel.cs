using CM.Music;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LaserRotation/New Music Level", fileName = "NewMusicLevel.asset")]
public class LR_MusicLevel : ScriptableObject, IMusicLevel
{
	[SerializeField]
	private int _bpm;
	public int Bpm { get => _bpm; }

	[SerializeField]
	private AudioData _audioData;
	public AudioData AudioData { get => _audioData; }

	public float cameraSize = 5;
	
	private List<Beat> _beats;

	#region LR_MusicLevel Set
	public void SetLaserPart(LaserPart laserPart, LaserTypes laserType, int beatIndex)
	{
		switch (laserType)
		{
			case LaserTypes.PreLaser:
				_beats[beatIndex].laser.preLaser = laserPart;
				LockProperties(laserPart, laserType, beatIndex);
				break;
			case LaserTypes.HitLaser:
				_beats[beatIndex].laser.hitLaser = laserPart;
				LockProperties(laserPart, laserType, beatIndex);
				break;
		}
	}

	public void SetLaser(Laser laser, int beatIndex)
	{
		_beats[beatIndex].laser = laser;
	}

	public void SetBeat(Beat beat, int beatIndex)
	{
		_beats[beatIndex] = beat;
	}

	public void SetWalls(Walls walls, int beatIndex)
	{
		_beats[beatIndex].walls = walls;
	}
	#endregion

	#region LR_MusicLevel Get
	public LaserPart GetLaserPart(LaserTypes laserType, int beatIndex)
	{
		switch (laserType)
		{
			case LaserTypes.PreLaser:
				return _beats[beatIndex].laser.preLaser;
			case LaserTypes.HitLaser:
				return _beats[beatIndex].laser.hitLaser;
		}

		return default;
	}

	public Laser GetLaser(int beatIndex)
	{
		return _beats[beatIndex].laser;
	}

	public Beat GetBeat(int beatIndex)
	{
		return _beats[beatIndex];
	}

	public Walls GetWalls(int beatIndex)
	{
		return _beats[beatIndex].walls;
	}

	public int GetBeatCount()
	{
		return _beats.Count;
	}
	#endregion

	public void LockProperties(LaserPart laserPart, LaserTypes laserType, int beatIndex)
	{
		switch (laserType)
		{
			case LaserTypes.PreLaser:
				_beats[beatIndex].laser.hitLaser.angle = laserPart.angle;
				_beats[beatIndex].laser.hitLaser.radius = laserPart.radius;
				break;
			case LaserTypes.HitLaser:
				_beats[beatIndex].laser.preLaser.angle = laserPart.angle;
				_beats[beatIndex].laser.preLaser.radius = laserPart.radius;
				break;
		}
	}

	public void ClearBeats()
	{
		_beats = new List<Beat>();
	}

	public void AddBeat(Beat beat)
	{
		_beats.Add(beat);
	}
}