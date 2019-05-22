using UnityEngine.SceneManagement;
using UnityEngine;
using CM.Essentials;

public class GameOverOnTrigger : MonoBehaviour
{
	private void Awake()
	{
		GetComponent<Trigger2D>().TriggerEvent += OnTrigger;
	}

	private void OnTrigger()
	{
		SceneManager.LoadScene(0);
	}
}
