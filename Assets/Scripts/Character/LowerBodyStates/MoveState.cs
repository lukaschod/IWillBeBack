using UnityEngine;

public class MoveState : State
{
	private Vector3 direction;
	private float force;
	private CharacterMovement movement;

	public MoveState(CharacterStates states) : base(states)
	{
		movement = states.GetComponent<CharacterMovement>();
	}

	public void OnSet(Vector3 preferredDirection, float preferredForce)
	{
		movement.MoveTo(preferredDirection, preferredForce);
	}

	public override void OnStep()
	{
	}

	public override void OnStop()
	{
		movement.Stop();
	}
}