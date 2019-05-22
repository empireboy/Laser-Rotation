using CM;
using CM.Music;
using UnityEngine;

public class WallsUIContainer : MonoBehaviour
{
	[SerializeField]
	private LR_WallsUI _wallsUI;

	[SerializeField]
	private GameObject _wallsUIActivation;

	public void Initialize(MusicLevelEditor editor, LR_MusicLevelSetup setup)
	{
		_wallsUI.Initialize(editor, setup);
	}

	public void Activate()
	{
		CM_Debug.Log("Beat Item UI", "Activating at " + this);

		_wallsUIActivation.SetActive(false);
	}

	public void Preset(int beatIndex)
	{
		_wallsUI.Preset(beatIndex);
	}
}
 