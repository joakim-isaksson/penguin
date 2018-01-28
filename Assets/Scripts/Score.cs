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
		if (Player != null) score.text = "" + Player.Contested;
	}
	
	public static Score Get()
	{
		return GameObject.FindGameObjectWithTag(typeof(Score).Name).GetComponent<Score>();
	}
}