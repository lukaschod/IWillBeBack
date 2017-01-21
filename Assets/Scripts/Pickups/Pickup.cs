using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		var stats = other.GetComponent<CharacterStats>();
		if (stats == null)
			return;
		OnPickup(stats);
		GameObject.Destroy(gameObject);
	}

	public abstract void OnPickup(CharacterStats target);
}
