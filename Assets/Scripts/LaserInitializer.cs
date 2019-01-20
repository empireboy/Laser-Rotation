using UnityEngine;
using CM.Music;
using CM.Essentials;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ColorChanger))]
[RequireComponent(typeof(ConstantForce2D))]
public class LaserInitializer : MonoBehaviour
{
	[HideInInspector] public int index;

	private RhythmController _rhythmController;
	private Rigidbody2D _rigidbody2d;
	private SpriteRenderer _spriteRenderer;
	private ColorChanger _colorChanger;
	private ConstantForce2D _constantForce2d;

	private void Awake()
	{
		_rhythmController = FindObjectOfType<RhythmController>();
		_rigidbody2d = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_colorChanger = GetComponent<ColorChanger>();
		_constantForce2d = GetComponent<ConstantForce2D>();
	}

	public void InitializeLaserPart(LaserPart laserPart)
	{
		_rigidbody2d.gravityScale = laserPart.gravity;
		_spriteRenderer.color = laserPart.startColor;
		_colorChanger.newColor = laserPart.finalColor;

		Vector2 force = Vector2.zero;
		if (laserPart.forceDirection == LaserPart.ForceDirections.forward)
			force = Quaternion.Euler(0, 0, laserPart.angle) * Vector2.left;
		if (laserPart.forceDirection == LaserPart.ForceDirections.backward)
			force = Quaternion.Euler(0, 0, laserPart.angle) * Vector2.right;
		if (laserPart.forceDirection == LaserPart.ForceDirections.left)
			force = Quaternion.Euler(0, 0, laserPart.angle) * Vector2.down;
		if (laserPart.forceDirection == LaserPart.ForceDirections.right)
			force = Quaternion.Euler(0, 0, laserPart.angle) * Vector2.up;
		GetComponent<ConstantForce2D>().force = force * laserPart.forceFactor;
	}
}