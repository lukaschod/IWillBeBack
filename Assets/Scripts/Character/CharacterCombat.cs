using UnityEngine;
using System.Collections.Generic;

public class CharacterCombat : MonoBehaviour
{
	[SerializeField] Weapon[] startingWeapons;
	private List<Weapon> weapons;
	private Weapon currentWeapon;

	public float ShotDuration { get { return currentWeapon.FireDuration; } }

	public bool IsReady()
	{
		if (currentWeapon == null)
			return false;
		return currentWeapon.IsReadyToShot();
	}

	public void AddWeapon(Weapon createFrom)
	{
		var weapon = Weapon.Create(createFrom, GetComponent<CharacterStats>());
		weapon.transform.SetParent(transform);
		weapon.transform.localPosition = Vector3.zero;
		weapons.Add(weapon);
		if (currentWeapon == null)
			SetCurrentWeapon(0);
	}

	public bool SetCurrentWeapon(int index)
	{
		if (index >= weapons.Count)
			return false;
		currentWeapon = weapons[index];
		return true;
	}

	public void StartShot()
	{
		currentWeapon.OnShotStart();
		currentWeapon.Shot();
	}

	public void FinishShot()
	{
		currentWeapon.OnShotFinish();
	}

	public void Reload()
	{
		if (currentWeapon == null)
			return;
		currentWeapon.Reload();
	}

	private void Awake()
	{
		weapons = new List<Weapon>();
		foreach (var weapon in startingWeapons)
			AddWeapon(weapon);
	}
}