using UnityEngine;

public class SwitchWeaponState : State
{
	private CharacterCombat combat;
	private float timeUntilSwitchLeft;
	private int weaponId;

	public SwitchWeaponState(CharacterStates states) : base(states) 
	{
		combat = states.GetComponent<CharacterCombat>();
	}

	public void OnSet(int weaponId)
	{
		timeUntilSwitchLeft = 0.3f;
		this.weaponId = weaponId;
		states.UpperBodyLocks++;
	}

	public override void OnStep()
	{
		timeUntilSwitchLeft -= Time.deltaTime;
		if (timeUntilSwitchLeft <= 0)
		{
			combat.SetCurrentWeapon(weaponId);
			states.UpperBodyLocks--;
			states.SetUpperIdle();
		}
	}

	public override void OnStop()
	{
	}
}