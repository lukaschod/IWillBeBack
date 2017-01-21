using UnityEngine;

public class CharacterStats : MonoBehaviour
{
	public float life = 100;

	public void DealDamage(float damage)
	{
		life -= damage;
		if (life <= 0)
			GameObject.Destroy(gameObject);
	}
}