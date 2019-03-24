using CM.Music;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "LaserRotation/New Rhythm Level", fileName = "NewRhythmLevel.asset")]
public class MusicLevel<T> : ScriptableObject, IRhythmLevel where T : class
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

	[SerializeField]
	private List<T> _beats = new List<T>();
	public List<T> Beats { get => _beats; }

	private string[] _perBeatTypes;
	public string[] PerBeatTypes { get => _perBeatTypes; }

	public float cameraSize = 5;

	#region MusicLevel Set
	public void SetBeat(T beat, int beatIndex)
	{
		_beats[beatIndex] = beat;
	}
	#endregion

	#region MusicLevel Get
	public T GetBeat(int beatIndex)
	{
		return _beats[beatIndex];
	}

	public int GetBeatCount()
	{
		return _beats.Count;
	}
	#endregion

	public void ClearBeats()
	{
		_beats = new List<T>();
	}

	public void AddBeat(T beat)
	{
		_beats.Add(beat);
	}
}