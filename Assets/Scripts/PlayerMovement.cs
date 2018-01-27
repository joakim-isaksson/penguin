using CnControls;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
	public float MoveForce;
	
	Player player;
	Rigidbody2D rb;

	void Awake()
	{
		player = GetComponent<Player>();
		rb = GetComponent<Rigidbody2D>();
		rb.isKinematic = !player.IsLocal;
	}

	void LateUpdate()
	{
		if (!player.IsLocal) return;
		
		var input = new Vector2(
			CnInputManager.GetAxis("Horizontal"),
			CnInputManager.GetAxis("Vertical")
		);
		
		if (input.magnitude > 1.0f) input.Normalize();
		
		rb.AddForce(input * player.Speed * MoveForce * Time.deltaTime);
	}
}