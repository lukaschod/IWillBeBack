using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] private float lifeSpan = 2;
	[SerializeField] private float speed = 5;
	[SerializeField] private float damage = 25;
	protected CharacterStats shoter;
	private float duration;

	public static Projectile Create(Projectile createFrom, CharacterStats shoter, Vector3 position, Quaternion angle)
	{
		var projectile = Instantiate(createFrom);
		projectile.transform.position = position;
		projectile.transform.localRotation = angle;
		projectile.shoter = shoter;
		return projectile;
	}

	public virtual void OnStart() {}
	public virtual void OnMove() {}
	public virtual void OnFinish() {}

	public virtual void OnHit(CharacterStats target)
	{
		if (target == shoter)
			return;
		target.DealDamage(damage);
		GameObject.Destroy(gameObject);
	}

	private void Awake()
	{
		duration = lifeSpan;
		OnStart();
	}

	private void OnTriggerEnter(Collider other)
	{
		var stats = other.GetComponent<CharacterStats>();
		if (stats == null)
			return;
		OnHit(stats);
	}

	private void Update()
	{
		duration -= Time.deltaTime;

		if (duration <= 0)
		{
			OnFinish();
			GameObject.Destroy(gameObject);
			return;
		}
		transform.position += transform.localRotation * Vector3.forward * speed * Time.deltaTime;
	}
}
