using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
	Player player;

	void Awake()
	{
		player = GetComponent<Player>();
	}

	void Update()
	{
		if (!player.IsLocal) return;
		
		var input = new Vector3(
			Input.GetAxis("Horizontal"),
			Input.GetAxis("Vertical")
		);
		
		// TODO: move with rigid bodies / player controller
		player.transform.position = player.transform.position + input * player.Speed * Time.deltaTime;
	}
}