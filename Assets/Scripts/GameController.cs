using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameObject PlayerPrefab;

	PlayArea playArea;

	void Awake()
	{
		playArea = PlayArea.Get();
	}

	public void JoinGame()
	{
		PhotonNetwork.Instantiate(PlayerPrefab.name, playArea.NextSpawnPoint(), Quaternion.identity, 0); 
	}

	public static GameController Get()
	{
		return GameObject.FindGameObjectWithTag(typeof(GameController).Name).GetComponent<GameController>();
	}
}