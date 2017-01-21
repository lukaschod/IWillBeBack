using UnityEngine;

public static class InputManager
{
	public static float GetHorizontal(int controlId)
	{
		if (controlId == 0)
			return Input.GetAxis("Horizontal");
		else
			return Input.GetAxis("Horizontal2");
	}

	public static float GetVertical(int controlId)
	{
		if (controlId == 0)
			return Input.GetAxis("Vertical");
		else
			return Input.GetAxis("Vertical2");
	}

	public static bool IsShoting(int controlId)
	{
		if (controlId == 0)
			return Input.GetAxis("Shot") == 1;
		else
			return Input.GetAxis("Shot2") == 1;
	}

	public static bool IsReloading(int controlId)
	{
		if (controlId == 0)
			return Input.GetAxis("Reload") == 1;
		else
			return Input.GetAxis("Reload2") == 1;
	}

	public static bool IsJumping(int controlId)
	{
		if (controlId == 0)
			return Input.GetAxis("Jump") == 1;
		else
			return Input.GetAxis("Jump2") == 1;
	}

	public static bool IsSwitchingWeapon(int controlId, int weaponId)
	{
		if (controlId == 0)
			return Input.GetAxis("Switch_" + weaponId.ToString()) == 1;
		else
			return Input.GetAxis("Switch2_" + weaponId.ToString()) == 1;
	}
}
