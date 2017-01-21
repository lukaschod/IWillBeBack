using UnityEngine;

public class ReloadState : State
{
	private CharacterCombat combat;
	private float timeUntilReloadLeft;

	public ReloadState(CharacterStates states) : base(states) 
	{
		combat = states.GetComponent<CharacterCombat>();
	}

	public void OnSet()
	{
		timeUntilReloadLeft = combat.ShotDuration;
		states.UpperBodyLocks++;
	}

	public override void OnStep()
	{
		timeUntilReloadLeft -= Time.deltaTime;
		if (timeUntilReloadLeft <= 0)
		{
			combat.Reload();
			states.UpperBodyLocks--;
			states.SetUpperIdle();
		}
	}

	public override void OnStop()
	{
	}
}