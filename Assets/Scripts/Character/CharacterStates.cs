using UnityEngine;

public class CharacterStates : MonoBehaviour
{
	private State currentUpperBodyState;
	private State currentLowerBodyState;
	private MoveState moveState;
	private IdleState idleState;
	private JumpState jumpState;
	private AttackState attackState;
	private ReloadState reloadState;
	private SwitchWeaponState switchWeaponState;

	public bool IsMoving { get { return currentLowerBodyState == moveState; } }
	public int UpperBodyLocks { get; set; }
	public int LowerBodyLocks { get; set; }

	public bool SwitchWeapon(int weaponId)
	{
		if (UpperBodyLocks != 0 )
			return false;
		Debug.Log("Switch weapon to" + weaponId.ToString());
		switchWeaponState.OnSet(weaponId);
		currentUpperBodyState.OnStop();
		currentUpperBodyState = switchWeaponState;
		return true;
	}

	public bool SetJump()
	{
		if (LowerBodyLocks != 0)
			return false;
		jumpState.OnSet();
		currentLowerBodyState.OnStop();
		currentLowerBodyState = jumpState;
		return true;
	}

	public bool SetUpperIdle()
	{
		if (UpperBodyLocks != 0)
			return false;
		idleState.OnSet();
		currentUpperBodyState.OnStop();
		currentUpperBodyState = idleState;
		return true;
	}

	public bool SetAttack()
	{
 		if (UpperBodyLocks != 0 || !attackState.IsReady)
			return false;
		attackState.OnSet();
		currentUpperBodyState.OnStop();
		currentUpperBodyState = attackState;
		return true;
	}

	public bool SetReload()
	{
		if (UpperBodyLocks != 0)
			return false;
		Debug.Log("Reload");
		reloadState.OnSet();
		currentUpperBodyState.OnStop();
		currentUpperBodyState = reloadState;
		return true;
	}

	public bool SetMove(Vector3 direction, float force)
	{
		if (LowerBodyLocks != 0)
			return false;
		moveState.OnSet(direction, force);
		currentLowerBodyState.OnStop();
		currentLowerBodyState = moveState;
		return true;
	}

	public bool SetIdle()
	{
		if (LowerBodyLocks != 0)
			return false;
		idleState.OnSet();
		currentLowerBodyState.OnStop();
		currentLowerBodyState = idleState;
		return true;
	}

	private void Awake()
	{
		moveState = new MoveState(this);
		idleState = new IdleState(this);
		jumpState = new JumpState(this);
		attackState = new AttackState(this);
		reloadState = new ReloadState(this);
		switchWeaponState = new SwitchWeaponState(this);
		currentLowerBodyState = idleState;
		currentUpperBodyState = idleState;
		SetIdle();
	}

	private void Update()
	{
		currentUpperBodyState.OnStep();
		currentLowerBodyState.OnStep();
	}
}