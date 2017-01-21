using UnityEngine;

public static class FixedDirection
{
	public static Vector3 ToFixedDirection(Vector3 preferredDirection)
	{
		float degress = Quaternion.LookRotation(preferredDirection, Vector3.up).eulerAngles.y;
		float cone = 22.5f;

		//Debug.Log(degress);

		if (InRange(degress, 0, cone) || 
			InRange(degress, 360, cone))
			return Vector3.right;

		if (InRange(degress, 45, cone))
			return (Vector3.forward + Vector3.right).normalized;

		if (InRange(degress, 90, cone))
			return Vector3.forward;

		if (InRange(degress, 135, cone))
			return (Vector3.forward + Vector3.left).normalized;

		if (InRange(degress, 180, cone))
			return Vector3.left;

		if (InRange(degress, 225, cone))
			return (Vector3.back + Vector3.left).normalized;

		if (InRange(degress, 270, cone))
			return Vector3.back;

		if (InRange(degress, 315, cone))
			return (Vector3.back + Vector3.right).normalized;
		return Vector3.zero;
	}

	private static bool InRange(float value, float center, float size)
	{
		return center - size <= value && value <= center + size;
	}
}

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
	[SerializeField] private float jumpForce;
	[SerializeField] private float moveForce;
	private Vector3 direction;
	private float force;
	private Rigidbody rigidBody;
	private bool isMoving;

	private void Awake()
	{
		rigidBody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		if (!isMoving)
			return;
		rigidBody.velocity += direction * force * moveForce;

		var currentSpeed = rigidBody.velocity.magnitude;
		if (currentSpeed > moveForce)
			rigidBody.velocity = rigidBody.velocity.normalized * moveForce;
	}

	public void MoveTo(Vector3 preferredDirection, float preferredForce)
	{
		direction = FixedDirection.ToFixedDirection(preferredDirection);
		transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
		force = preferredForce;
		isMoving = true;
	}

	public void Jump()
	{
		rigidBody.AddForce(Vector3.up * jumpForce);
	}
		
	public void Stop()
	{
		isMoving = false;
	}
}