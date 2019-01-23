using UnityEngine;
using UnityEngine.UI;
using CM.Music;

public class LaserUI : MonoBehaviour
{
	[HideInInspector] public int index;

	public LaserTypes laserType;

	public Text typeText;

	public InputField startColorRInputField;
	public InputField startColorGInputField;
	public InputField startColorBInputField;
	public InputField startColorAInputField;

	public InputField finalColorRInputField;
	public InputField finalColorGInputField;
	public InputField finalColorBInputField;
	public InputField finalColorAInputField;

	public Dropdown forceDirectionDropdown;
	public InputField forceFactorInputField;

	public InputField angleInputField;
	public InputField radiusInputField;

	private LR_MusicLevelSetup _musicLevelSetup;
	private MusicLevelEditor _musicLevelEditor;

	private void Awake()
	{
		_musicLevelSetup = FindObjectOfType<LR_MusicLevelSetup>();
		_musicLevelEditor = FindObjectOfType<MusicLevelEditor>();
	}

	private void Start()
	{
		typeText.text = laserType.ToString();
		Preset();
	}

	public void Apply()
	{
		LaserPart laserPart = new LaserPart
		{
			angle = int.Parse(angleInputField.text),
			radius = int.Parse(radiusInputField.text),
			startColor = new Color(
				float.Parse(startColorRInputField.text) / 255,
				float.Parse(startColorGInputField.text) / 255,
				float.Parse(startColorBInputField.text) / 255,
				float.Parse(startColorAInputField.text)
			),
			finalColor = new Color(
				float.Parse(finalColorRInputField.text) / 255,
				float.Parse(finalColorGInputField.text) / 255,
				float.Parse(finalColorBInputField.text) / 255,
				float.Parse(finalColorAInputField.text)
			),
			forceFactor = int.Parse(forceFactorInputField.text)
		};
		switch (forceDirectionDropdown.value)
		{
			case 0:
				laserPart.forceDirection = LaserPart.ForceDirections.forward;
				break;
			case 1:
				laserPart.forceDirection = LaserPart.ForceDirections.backward;
				break;
			case 2:
				laserPart.forceDirection = LaserPart.ForceDirections.left;
				break;
			case 3:
				laserPart.forceDirection = LaserPart.ForceDirections.right;
				break;
		}

		if (laserType == LaserTypes.PreLaser)
			_musicLevelSetup.musicLevel.beats[index].laser.preLaser = laserPart;

		if (laserType == LaserTypes.HitLaser)
			_musicLevelSetup.musicLevel.beats[index].laser.hitLaser = laserPart;

		_musicLevelEditor.UpdateIndex();
	}

	public void Preset()
	{
		LaserPart laserPart = new LaserPart();

		if (laserType == LaserTypes.PreLaser)
			laserPart = _musicLevelSetup.musicLevel.beats[index].laser.preLaser;

		if (laserType == LaserTypes.HitLaser)
			laserPart = _musicLevelSetup.musicLevel.beats[index].laser.hitLaser;

		angleInputField.text = laserPart.angle.ToString();
		radiusInputField.text = laserPart.radius.ToString();

		startColorRInputField.text = (laserPart.startColor.r * 255).ToString();
		startColorGInputField.text = (laserPart.startColor.g * 255).ToString();
		startColorBInputField.text = (laserPart.startColor.b * 255).ToString();
		startColorAInputField.text = (laserPart.startColor.a).ToString();

		finalColorRInputField.text = (laserPart.finalColor.r * 255).ToString();
		finalColorGInputField.text = (laserPart.finalColor.g * 255).ToString();
		finalColorBInputField.text = (laserPart.finalColor.b * 255).ToString();
		finalColorAInputField.text = (laserPart.finalColor.a).ToString();

		switch (laserPart.forceDirection)
		{
			case LaserPart.ForceDirections.forward:
				forceDirectionDropdown.value = 0;
				break;
			case LaserPart.ForceDirections.backward:
				forceDirectionDropdown.value = 1;
				break;
			case LaserPart.ForceDirections.left:
				forceDirectionDropdown.value = 2;
				break;
			case LaserPart.ForceDirections.right:
				forceDirectionDropdown.value = 3;
				break;
		}
		forceFactorInputField.text = laserPart.forceFactor.ToString();
	}

	public void Remove()
	{
		_musicLevelSetup.musicLevel.beats[index] = new Beat();

		FindObjectOfType<MusicLevelEditor>().UpdateIndex();

		Destroy(gameObject);
	}
}