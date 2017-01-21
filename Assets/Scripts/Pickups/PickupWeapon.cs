using UnityEngine;

public class PickupWeapon : Pickup
{
	[SerializeField] private Weapon weaponToPickup;

	public override void OnPickup(CharacterStats target)
	{
		var combat = target.GetComponent<CharacterCombat>();
		combat.AddWeapon(weaponToPickup);
	}
}
