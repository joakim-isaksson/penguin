using UnityEngine;

public class FollowLocalPlayer : MonoBehaviour
{
	public float Speed;

	Vector3 offset;
	Player targetPlayer;

	void Awake()
	{
		offset = transform.position;
		Player.OnPlayerJoined += FollowPlayer;
	}

	void Update()
	{
		if (targetPlayer == null) return;

		var target = targetPlayer.transform.position + offset;
		var step = Speed * Mathf.Pow(1 + Vector3.Distance(transform.position, target), 2) * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target, step);
	}

	void FollowPlayer(Player player)
	{
		if (player.IsLocal) targetPlayer = player;
	}
}