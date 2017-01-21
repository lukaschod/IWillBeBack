using UnityEngine;

public class WeaponTest : ProjectileWeapon
{
	public override int MagazineCapacity { get { return 15; } }
	public override float ReloadDuration { get { return 1; } }
	public override float FireDuration { get {return 0.1f; } }
}