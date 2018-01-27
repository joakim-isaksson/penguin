using UnityEngine;

public class ColorManager : MonoBehaviour
{
	public Color[] ColorValues;
	
	[HideInInspector] public GameColor[] Colors;
	
	void Awake()
	{
		Colors = new GameColor[ColorValues.Length];
		for (var i = 0; i < Colors.Length; ++i)
		{
			var color = new GameColor
			{
				Index = i,
				Value = ColorValues[i],
				Type = i % 2 == 0 ? ColorType.Strong : ColorType.Weak
			};
			Colors[i] = color;
		}
	}

	public GameColor GetRandomColor()
	{
		return Colors[Random.Range(0, Colors.Length)];
	}
	
	public static ColorManager Get()
	{
		return GameObject.FindGameObjectWithTag(typeof(ColorManager).Name).GetComponent<ColorManager>();
	}
}

public struct GameColor
{
	public int Index;
	public Color Value;
	public ColorType Type;
}

public enum ColorType
{
	Strong, Weak
}