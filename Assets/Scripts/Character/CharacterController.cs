using UnityEngine;

[RequireComponent(typeof(CharacterStates))]
public class CharacterController : MonoBehaviour
{
	[SerializeField] private int controlId;
	private CharacterStates states;

	private void Awake()
	{
		states = GetComponent<CharacterStates>();
	}

	private void Update()
	{
		var moveVelocity = new Vector3(InputManager.GetVertical(controlId), 0, InputManager.GetHorizontal(controlId));
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

		if (InputManager.IsJumping(controlId))
		{
			states.SetJump();
		}

		if (InputManager.IsShoting(controlId))
		{
			states.SetAttack();
		}

		if (InputManager.IsReloading(controlId))
		{
			states.SetReload();
		}

		if (InputManager.IsSwitchingWeapon(controlId, 0))
		{
			states.SwitchWeapon(0);
		}

		if (InputManager.IsSwitchingWeapon(controlId, 1))
		{
			states.SwitchWeapon(1);
		}
	}
}