using UnityEngine;

public class InputManager : Manager<InputManager> 
{
	public float Horizontal { get; private set; }
	public float Vertical { get; private set; }
	public bool IsShoting { get; private set; }
	public bool IsReloading { get; private set; }
	public bool IsJumping { get; private set; }

	private void Update()
	{
		Horizontal = Input.GetAxis("Horizontal");
		Vertical = Input.GetAxis("Vertical");
		IsShoting = Input.GetAxis("Fire1") == 1;
		IsReloading = Input.GetAxis("Fire2") == 1;
		IsJumping = Input.GetAxis("Jump") == 1;
	}
}
