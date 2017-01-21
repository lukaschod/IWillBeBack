using UnityEngine;

public class JumpState : State
{
	private CharacterMovement movement;
	private Collider collider;
	private float moveDuration;

	public JumpState(CharacterStates states) : base(states)
	{
		movement = states.GetComponent<CharacterMovement>();
		collider = states.GetComponent<Collider>();
	}

	public void OnSet()
	{
		states.LowerBodyLocks++;
		movement.Jump();
		moveDuration = 0.5f;
	}

	public override void OnStep()
	{
		moveDuration -= Time.deltaTime;
		if (IsGrounded() && moveDuration <= 0)
		{
			states.LowerBodyLocks--;
			states.SetIdle();
		}
	}

	private bool IsGrounded()
	{
		return Physics.Raycast(states.transform.position, Vector3.down, 0.1f + collider.bounds.extents.y);
	}

	public override void OnStop()
	{
	}
}