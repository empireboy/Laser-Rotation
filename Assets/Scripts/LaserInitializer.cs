using UnityEngine;
using CM.Music;
/*
public class LaserInitializer : MonoBehaviour
{
	[HideInInspector]
	public int index;

	private RhythmController _rhythmController;

	private void Awake()
	{
		_rhythmController = FindObjectOfType<RhythmController>();
	}

	public void InitializePreLaser()
	{
		GetComponent<Rigidbody2D>().gravityScale = _rhythmController.Level.beats[index].laser.preLaser.gravity;
		GetComponent<SpriteRenderer>().color = _rhythmController.Level.beats[index].laser.preLaser.startColor;
		GetComponent<CM.Essentials.ColorChanger>().newColor = _rhythmController.Level.beats[index].laser.preLaser.finalColor;

		Vector2 force = Vector2.zero;
		if (_rhythmController.Level.beats[index].laser.preLaser.forceDirection == LaserPart.ForceDirections.forward)
			force = Quaternion.Euler(0, 0, _rhythmController.Level.beats[index].laser.preLaser.angle) * Vector2.left;
		if (_rhythmController.Level.beats[index].laser.preLaser.forceDirection == LaserPart.ForceDirections.backward)
			force = Quaternion.Euler(0, 0, _rhythmController.Level.beats[index].laser.preLaser.angle) * Vector2.right;
		if (_rhythmController.Level.beats[index].laser.preLaser.forceDirection == LaserPart.ForceDirections.left)
			force = Quaternion.Euler(0, 0, _rhythmController.Level.beats[index].laser.preLaser.angle) * Vector2.down;
		if (_rhythmController.Level.beats[index].laser.preLaser.forceDirection == LaserPart.ForceDirections.right)
			force = Quaternion.Euler(0, 0, _rhythmController.Level.beats[index].laser.preLaser.angle) * Vector2.up;
		GetComponent<ConstantForce2D>().force = force * _rhythmController.Level.beats[index].laser.preLaser.forceFactor;
	}

	public void InitializeHitLaser()
	{
		GetComponent<Rigidbody2D>().gravityScale = _rhythmController.Level.beats[index].laser.hitLaser.gravity;
		GetComponent<SpriteRenderer>().color = _rhythmController.Level.beats[index].laser.hitLaser.startColor;
		GetComponent<CM.Essentials.ColorChanger>().newColor = _rhythmController.Level.beats[index].laser.hitLaser.finalColor;

		Vector2 force = Vector2.zero;
		if (_rhythmController.Level.beats[index].laser.hitLaser.forceDirection == LaserPart.ForceDirections.forward)
			force = Quaternion.Euler(0, 0, _rhythmController.Level.beats[index].laser.hitLaser.angle) * Vector2.left;
		if (_rhythmController.Level.beats[index].laser.hitLaser.forceDirection == LaserPart.ForceDirections.backward)
			force = Quaternion.Euler(0, 0, _rhythmController.Level.beats[index].laser.hitLaser.angle) * Vector2.right;
		if (_rhythmController.Level.beats[index].laser.hitLaser.forceDirection == LaserPart.ForceDirections.left)
			force = Quaternion.Euler(0, 0, _rhythmController.Level.beats[index].laser.hitLaser.angle) * Vector2.down;
		if (_rhythmController.Level.beats[index].laser.hitLaser.forceDirection == LaserPart.ForceDirections.right)
			force = Quaternion.Euler(0, 0, _rhythmController.Level.beats[index].laser.hitLaser.angle) * Vector2.up;
		GetComponent<ConstantForce2D>().force = force * _rhythmController.Level.beats[index].laser.hitLaser.forceFactor;
	}
}
*/