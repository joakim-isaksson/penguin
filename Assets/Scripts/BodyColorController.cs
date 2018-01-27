using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BodyColorController : MonoBehaviour
{
	public Player Player;

	SpriteRenderer spriteRenderer;
	
	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	void Update()
	{
		spriteRenderer.color = Player.color;
	}
}