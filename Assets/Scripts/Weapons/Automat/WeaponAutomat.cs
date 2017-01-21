using UnityEngine;

public class WeaponAutomat : Weapon
{
	[SerializeField] protected Projectile SpawnOnShot;
	[SerializeField] protected Transform shotPoint;
	public override int MagazineCapacity { get { return 15; } }
	public override float ReloadDuration { get { return 1; } }
	public override float FireDuration { get {return 0.1f; } }

	public override void OnShotFinish()
	{
		var projectile = Projectile.Create(SpawnOnShot, shoter, shotPoint.localPosition + transform.position, transform.rotation);
		projectile.transform.Rotate(Vector3.up, Random.Range(-20, 20));
	}
}