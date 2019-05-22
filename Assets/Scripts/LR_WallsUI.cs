using UnityEngine.UI;

public class LR_WallsUI : LR_BeatItemUI<WallsData>
{
	public Toggle frontToggle;
	public Toggle backToggle;
	public Toggle leftToggle;
	public Toggle rightToggle;

	public override WallsData GetDataFromUI()
	{
		WallsData wallsData = new WallsData
		{
			front = frontToggle.isOn,
			back = backToggle.isOn,
			left = leftToggle.isOn,
			right = rightToggle.isOn
		};

		return wallsData;
	}

	public override void Preset(int beatIndex)
	{
		WallsData wallsData = musicLevelSetup.musicLevel.GetBeat(beatIndex).walls;

		frontToggle.isOn = wallsData.front;
		backToggle.isOn = wallsData.back;
		leftToggle.isOn = wallsData.left;
		rightToggle.isOn = wallsData.right;
	}

	public override void Apply()
	{
		WallsData wallsData = GetDataFromUI();

		musicLevelSetup.musicLevel.GetBeat(musicLevelEditor.CurrentIndex).walls = wallsData;

		base.Apply();
	}

	public override void Remove()
	{
		musicLevelSetup.musicLevel.SetBeat(new LR_Beat(), musicLevelEditor.CurrentIndex);

		base.Remove();
	}
}