using UnityEngine;

public abstract class ProjectileWeapon : Weapon
{
	[SerializeField] protected Projectile SpawnOnShot;
	[SerializeField] protected Vector3 spawnOffset;

	public override void OnShotFinish()
	{
		Projectile.Create(SpawnOnShot, shoter, spawnOffset + transform.position, transform.rotation);
	}
}