using CM;
using CM.Music;
using UnityEngine;

public class LaserPartUIContainer : MonoBehaviour
{
	[SerializeField]
	private LR_LaserUI _laserUI;

	[SerializeField]
	private GameObject _laserUIActivation;

	public void Initialize(MusicLevelEditor editor, LR_MusicLevelSetup setup, LR_MusicLevelEditorSpawning spawning)
	{
		_laserUI.Initialize(editor, setup, spawning);
	}

	public void SetLaserType(LaserTypes laserType)
	{
		_laserUI.SetLaserType(laserType);
	}

	public void Activate()
	{
		CM_Debug.Log("Beat Item UI", "Activating at " + this);

		_laserUIActivation.SetActive(false);
	}

	public void Preset(int beatIndex)
	{
		_laserUI.Preset(beatIndex);
	}
}