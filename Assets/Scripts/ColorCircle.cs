using UnityEngine;

public class ColorCircle : MonoBehaviour
{
	SpriteRenderer spriteRenderer;
	Player owner;
	
	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		var player = other.gameObject.GetComponent<Player>();
		if (player == null) return;

		if (owner != null) owner.Contested--;
		player.Contested++;
		owner = player;
		spriteRenderer.color = player.Color;
	}
}