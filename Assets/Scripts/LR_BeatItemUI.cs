using CM;
using CM.Music;
using UnityEngine;

public abstract class LR_BeatItemUI<T> : MonoBehaviour
{
	public GameObject activationUI;

	protected MusicLevelEditor musicLevelEditor;
	protected LR_MusicLevelSetup musicLevelSetup;

	public virtual void Initialize(MusicLevelEditor editor, LR_MusicLevelSetup setup)
	{
		CM_Debug.Log("Beat Item UI", "Initializing start at " + this);

		musicLevelEditor = editor;
		musicLevelSetup = setup;

		CM_Debug.Log("Beat Item UI", "Initializing finish at " + this);
	}

	public virtual void Activate()
	{
		activationUI.SetActive(false);

		CM_Debug.Log("Beat Item UI", "Activating at " + this);
	}

	public virtual void Apply()
	{
		CM_Debug.Log("Beat Item UI", "Applying at " + this);

		musicLevelEditor.UpdateIndex();
	}

	public virtual void Preset(int beatIndex)
	{
		CM_Debug.Log("Beat Item UI", "Presetting at " + this);
	}

	public abstract T GetDataFromUI();
	
	public virtual void Remove()
	{
		musicLevelEditor.UpdateIndex();

		CM_Debug.Log("Beat Item UI", "Removing at " + this);
	}
}