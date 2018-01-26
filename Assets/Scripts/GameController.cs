using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameObject PlayerPrefab;

	SpawnArea spawnArea;

	void Awake()
	{
		spawnArea = SpawnArea.Get();
	}

	public void JoinGame()
	{
		PhotonNetwork.Instantiate(PlayerPrefab.name, spawnArea.GetRandomSpawnPoint(), Quaternion.identity, 0); 
	}

	public static GameController Get()
	{
		return GameObject.FindGameObjectWithTag(typeof(GameController).Name).GetComponent<GameController>();
	}
}