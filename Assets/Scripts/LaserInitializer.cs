using UnityEngine;
using CM.Music;
using CM.Essentials;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ColorChanger))]
[RequireComponent(typeof(ConstantForce2D))]
[RequireComponent(typeof(LaserSpawner))]
public class LaserInitializer : MonoBehaviour
{
	[HideInInspector] public int index;

	public GameObject ui;

	private bool _isActivated = false;
	public bool IsActivated { get => _isActivated; }

	private RhythmController _rhythmController;
	private Rigidbody2D _rigidbody2d;
	private SpriteRenderer _spriteRenderer;
	private ColorChanger _colorChanger;
	private ConstantForce2D _constantForce2d;
	private LaserSpawner _laserSpawner;

	private void Awake()
	{
		_rhythmController = FindObjectOfType<RhythmController>();
		_rigidbody2d = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_colorChanger = GetComponent<ColorChanger>();
		_constantForce2d = GetComponent<ConstantForce2D>();
		_laserSpawner = GetComponent<LaserSpawner>();
	}

	public void ActivateLaser()
	{
		_isActivated = true;

		if (_laserSpawner) _laserSpawner.SetNextSpawn();

		_colorChanger.enabled = true;

		PolygonCollider2D polygonCollider2d = GetComponent<PolygonCollider2D>();
		if (polygonCollider2d) polygonCollider2d.enabled = true;

		_constantForce2d.enabled = true;
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

	public void CreateUI(int index, LaserTypes laserType)
	{
		LaserUI laserUI = Instantiate(ui, GameObject.FindGameObjectWithTag("LaserUIContainer").transform).GetComponent<LaserUI>();
		laserUI.Initialize(index, laserType);
	}
}