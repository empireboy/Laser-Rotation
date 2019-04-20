using CM.Music;
using UnityEngine;

public abstract class LR_BeatItemUI<T> : MonoBehaviour
{
	protected MusicLevelEditor musicLevelEditor;
	protected LR_MusicLevelSetup musicLevelSetup;

	protected int beatIndex;

	public virtual void Initialize(int beatIndex, MusicLevelEditor editor, LR_MusicLevelSetup setup)
	{
		this.beatIndex = beatIndex;

		musicLevelEditor = editor;
		musicLevelSetup = setup;

		Preset(beatIndex);
	}

	public virtual void Apply()
	{
		musicLevelEditor.UpdateIndex();
	}

	public abstract void Preset(int beatIndex);

	public abstract T GetDataFromUI();
	
	public virtual void Remove()
	{
		musicLevelEditor.UpdateIndex();
	}
}