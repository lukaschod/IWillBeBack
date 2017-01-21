using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
	protected float currentRecoilDuration;
	protected CharacterStats shoter;
	
	public int AmmoInMagazine { get; set; }
	public int Ammo { get; set; }
	public Weapon CreatedFrom { get; private set; }
	public abstract int MagazineCapacity { get; }
	public abstract float ReloadDuration { get; }
	public abstract float FireDuration { get; }

	public static Weapon Create(Weapon createFrom, CharacterStats shoter)
	{
		var weapon = Instantiate(createFrom);
		weapon.shoter = shoter;
		weapon.CreatedFrom = createFrom;
		return weapon;
	}

	public virtual void OnShotStart() {}
	public virtual void OnShotFinish() {}

	public virtual bool IsReadyToShot()
	{
		return currentRecoilDuration <= 0 && AmmoInMagazine > 0;
	}

	public void Shot()
	{
		AmmoInMagazine--;
		currentRecoilDuration = 0.1f;
	}

	public void Reload()
	{
		if (Ammo >= MagazineCapacity)
		{
			AmmoInMagazine = MagazineCapacity;
			Ammo -= MagazineCapacity;
		}
		else
		{
			AmmoInMagazine = Ammo;
			Ammo = 0;
		}
	}

	private void Awake()
	{
		AmmoInMagazine = MagazineCapacity;
		Ammo = MagazineCapacity * 2;
	}

	private void Update()
	{
		currentRecoilDuration -= Time.deltaTime;
	}
}