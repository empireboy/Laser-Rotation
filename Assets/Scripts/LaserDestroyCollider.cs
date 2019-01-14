using System.Collections;
using UnityEngine;

public class LaserDestroyCollider : MonoBehaviour
{
	public float seconds = 0.5f;

	private void Start()
	{
		StartCoroutine(DestroyColliderRoutine());
	}

	private IEnumerator DestroyColliderRoutine()
	{
		yield return new WaitForSeconds(seconds);
		Destroy(GetComponent<BoxCollider2D>());
	}
}