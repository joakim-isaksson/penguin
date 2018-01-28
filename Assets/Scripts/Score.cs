using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	[HideInInspector] public Player Player;
	Text score;
	
	void Awake()
	{
		score = GetComponent<Text>();
	}

	void Update()
	{
		if (Player == null) return;
		var value = (int)(Player.Contested / 400.0f * 100);
		score.text = value + "%";
	}
	
	public static Score Get()
	{
		return GameObject.FindGameObjectWithTag(typeof(Score).Name).GetComponent<Score>();
	}
}