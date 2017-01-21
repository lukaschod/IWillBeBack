using UnityEngine;

public class AttackState : State
{
	private CharacterCombat combat;
	private float timeUntilShotLeft;

	public bool IsReady { get { return combat.IsReady() && timeUntilShotLeft <= 0; } }

	public AttackState(CharacterStates states) : base(states)
	{
		combat = states.GetComponent<CharacterCombat>();
	}

	public void OnSet()
	{
		combat.StartShot();
		timeUntilShotLeft = combat.ShotDuration;
		states.UpperBodyLocks++;
	}

	public override void OnStep()
	{
		timeUntilShotLeft -= Time.deltaTime;
		if (timeUntilShotLeft <= 0)
		{
			combat.FinishShot();
			states.UpperBodyLocks--;
			states.SetUpperIdle();
		}
	}

	public override void OnStop()
	{
	}
}