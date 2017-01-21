using UnityEngine;

[RequireComponent(typeof(CharacterStates))]
public class CharacterController : MonoBehaviour
{
	private CharacterStates states;

	private void Awake()
	{
		states = GetComponent<CharacterStates>();
	}

	private void Update()
	{
		var moveVelocity = new Vector3(InputManager.Instance.Vertical, 0, InputManager.Instance.Horizontal);
		var force = moveVelocity.magnitude;

		if (!states.IsMoving)
		{
			if (force > 0)
				states.SetMove(moveVelocity / force, force);
		}
		else
		{
			states.SetIdle();
		}

		if (InputManager.Instance.IsJumping)
		{
			states.SetJump();
		}

		if (InputManager.Instance.IsShoting)
		{
			states.SetAttack();
		}

		if (InputManager.Instance.IsReloading)
		{
			states.SetReload();
		}
	}
}