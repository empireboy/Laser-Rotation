using CM.Music;
using UnityEngine;
using UnityEngine.UI;

public class LR_LaserUI : LR_BeatItemUI<LaserPartData>
{
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

	public void Initialize(int beatIndex, MusicLevelEditor editor, LR_MusicLevelSetup setup, LaserTypes laserType)
	{
		_laserType = laserType;
		typeText.text = _laserType.ToString();

		base.Initialize(beatIndex, editor, setup);
	}

	public override LaserPartData GetDataFromUI()
	{
		LaserPartData laserPartData = new LaserPartData
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
				laserPartData.forceDirection = LaserPartData.ForceDirections.forward;
				break;
			case 1:
				laserPartData.forceDirection = LaserPartData.ForceDirections.backward;
				break;
			case 2:
				laserPartData.forceDirection = LaserPartData.ForceDirections.left;
				break;
			case 3:
				laserPartData.forceDirection = LaserPartData.ForceDirections.right;
				break;
		}

		return laserPartData;
	}

	public override void Preset(int beatIndex)
	{
		LaserPartData laserPartData = musicLevelSetup.musicLevel.GetBeat(beatIndex).laser.GetLaserPart(_laserType);

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

	public override void Apply()
	{
		LaserPartData laserPartData = GetDataFromUI();

		musicLevelSetup.musicLevel.GetBeat(beatIndex).laser.SetLaserPart(laserPartData, _laserType);

		base.Apply();
	}

	public override void Remove()
	{
		musicLevelSetup.musicLevel.SetBeat(new LR_Beat(), beatIndex);

		base.Remove();
	}
}