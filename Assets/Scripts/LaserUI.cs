using UnityEngine;
using UnityEngine.UI;
using CM.Music;

public class LaserUI : MonoBehaviour
{
	private int _beatIndex;
	private LaserTypes _laserType;

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
	public InputField gravityInputField;

	public InputField angleInputField;
	public InputField radiusInputField;

	private LR_MusicLevelSetup _musicLevelSetup;
	private MusicLevelEditor _musicLevelEditor;
	private LR_MusicLevelEditorSpawning _musicLevelEditorSpawning;

	private void Awake()
	{
		_musicLevelSetup = FindObjectOfType<LR_MusicLevelSetup>();
		_musicLevelEditor = FindObjectOfType<MusicLevelEditor>();
		_musicLevelEditorSpawning = FindObjectOfType<LR_MusicLevelEditorSpawning>();
	}

	private void Start()
	{
		typeText.text = _laserType.ToString();
		Preset(_beatIndex);
	}

	public void Initialize(int beatIndex, LaserTypes laserType)
	{
		_beatIndex = beatIndex;
		_laserType = laserType;
	}

	public void Apply()
	{
		LaserPartData laserPartData = GetLaserPartFromUI();

		_musicLevelSetup.musicLevel.GetBeat(_beatIndex).laser.SetLaserPart(laserPartData, _laserType);

		_musicLevelEditor.UpdateIndex();
	}

	public void Preset(int beatIndex)
	{
		LaserPartData laserPartData = _musicLevelSetup.musicLevel.GetBeat(beatIndex).laser.GetLaserPart(_laserType);

		angleInputField.text = laserPartData.angle.ToString();
		radiusInputField.text = laserPartData.radius.ToString();

		startColorRInputField.text = (laserPartData.startColor.r * 255).ToString();
		startColorGInputField.text = (laserPartData.startColor.g * 255).ToString();
		startColorBInputField.text = (laserPartData.startColor.b * 255).ToString();
		startColorAInputField.text = (laserPartData.startColor.a).ToString();

		finalColorRInputField.text = (laserPartData.finalColor.r * 255).ToString();
		finalColorGInputField.text = (laserPartData.finalColor.g * 255).ToString();
		finalColorBInputField.text = (laserPartData.finalColor.b * 255).ToString();
		finalColorAInputField.text = (laserPartData.finalColor.a).ToString();

		switch (laserPartData.forceDirection)
		{
			case LaserPartData.ForceDirections.forward:
				forceDirectionDropdown.value = 0;
				break;
			case LaserPartData.ForceDirections.backward:
				forceDirectionDropdown.value = 1;
				break;
			case LaserPartData.ForceDirections.left:
				forceDirectionDropdown.value = 2;
				break;
			case LaserPartData.ForceDirections.right:
				forceDirectionDropdown.value = 3;
				break;
		}
		forceFactorInputField.text = laserPartData.forceFactor.ToString();
		gravityInputField.text = laserPartData.gravity.ToString();
	}

	private LaserPartData GetLaserPartFromUI()
	{
		LaserPartData laserPart = new LaserPartData
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
			forceFactor = int.Parse(forceFactorInputField.text),
			gravity = int.Parse(gravityInputField.text)
		};
		switch (forceDirectionDropdown.value)
		{
			case 0:
				laserPart.forceDirection = LaserPartData.ForceDirections.forward;
				break;
			case 1:
				laserPart.forceDirection = LaserPartData.ForceDirections.backward;
				break;
			case 2:
				laserPart.forceDirection = LaserPartData.ForceDirections.left;
				break;
			case 3:
				laserPart.forceDirection = LaserPartData.ForceDirections.right;
				break;
		}

		return laserPart;
	}

	public void Remove()
	{
		_musicLevelSetup.musicLevel.SetBeat(new LR_Beat(), _beatIndex);

		FindObjectOfType<MusicLevelEditor>().UpdateIndex();

		Destroy(gameObject);
	}
}