using UnityEngine;
using UnityEngine.UI;
using CM.Music;

public class WallsUI : MonoBehaviour
{
	private int _beatIndex;

	public Toggle frontToggle;
	public Toggle backToggle;
	public Toggle leftToggle;
	public Toggle rightToggle;

	private LR_MusicLevelSetup _musicLevelSetup;
	private MusicLevelEditor _musicLevelEditor;

	private void Awake()
	{
		_musicLevelSetup = FindObjectOfType<LR_MusicLevelSetup>();
		_musicLevelEditor = FindObjectOfType<MusicLevelEditor>();
	}

	private void Start()
	{
		Preset(_beatIndex);
	}

	public void Initialize(int beatIndex)
	{
		_beatIndex = beatIndex;
	}

	public void Apply()
	{
		WallsData wallsData = GetWallsDataFromUI();

		_musicLevelSetup.musicLevel.GetBeat(_beatIndex).walls = wallsData;

		_musicLevelEditor.UpdateIndex();
	}

	public void Preset(int beatIndex)
	{
		WallsData wallsData = _musicLevelSetup.musicLevel.GetBeat(beatIndex).walls;

		frontToggle.isOn = wallsData.front;
		backToggle.isOn = wallsData.back;
		leftToggle.isOn = wallsData.left;
		rightToggle.isOn = wallsData.right;
	}

	private WallsData GetWallsDataFromUI()
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

	public void Remove()
	{
		_musicLevelSetup.musicLevel.SetBeat(new LR_Beat(), _beatIndex);

		FindObjectOfType<MusicLevelEditor>().UpdateIndex();

		Destroy(gameObject);
	}
}