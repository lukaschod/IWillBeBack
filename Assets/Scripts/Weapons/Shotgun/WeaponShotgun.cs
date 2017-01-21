using UnityEngine;

public class WeaponShotgun : Weapon
{
	[SerializeField] protected Projectile SpawnOnShot;
	[SerializeField] protected Transform shotPoint;
	public override int MagazineCapacity { get { return 4; } }
	public override float ReloadDuration { get { return 0.6f; } }
	public override float FireDuration { get {return 0.2f; } }

	public override void OnShotFinish()
	{
		for (int i = 0; i < 5; i++)
		{
			var projectile = Projectile.Create(SpawnOnShot, shoter, shotPoint.localPosition + transform.position, transform.rotation);
			projectile.transform.Rotate(Vector3.up, Random.Range(-20, 20));
		}
	}
}