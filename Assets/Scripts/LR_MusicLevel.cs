using CM.Music;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LaserRotation/New Rhythm Level", fileName = "NewRhythmLevel.asset")]
public class LR_MusicLevel : ScriptableObject, IRhythmLevel
{
	[SerializeField]
	private int _bpm;
	public int Bpm { get => _bpm; }

	[SerializeField]
	private int _beatsBeforeLevelStarts = 8;
	public int BeatsBeforeLevelStarts { get => _beatsBeforeLevelStarts; }

	[SerializeField]
	private AudioData _audioData;
	public AudioData AudioData { get => _audioData; }

	private string[] _perBeatTypes;
	public string[] PerBeatTypes { get => _perBeatTypes; }

	public float cameraSize = 5;

	[SerializeField]
	private List<LR_Beat> _beats;

	#region LR_MusicLevel Set
	public void SetBeat(LR_Beat beat, int beatIndex)
	{
		_beats[beatIndex] = beat;
	}

	/*public void SetWalls(Walls walls, int beatIndex)
	{
		_beats[beatIndex].walls = walls;
	}*/
	#endregion

	#region LR_MusicLevel Get

	public LR_Beat GetBeat(int beatIndex)
	{
		return _beats[beatIndex];
	}

	/*public Walls GetWalls(int beatIndex)
	{
		return _beats[beatIndex].walls;
	}*/

	public int GetBeatCount()
	{
		return _beats.Count;
	}
	#endregion

	public void ClearBeats()
	{
		_beats = new List<LR_Beat>();
	}

	public void AddBeat(LR_Beat beat)
	{
		_beats.Add(beat);
	}
}