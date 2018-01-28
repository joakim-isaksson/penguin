using UnityEngine;

public class GameController : Photon.MonoBehaviour
{
	public byte MaxNumberOfPlayers = 12;
	public GameObject[] PlayerPrefabs;

	PlayArea playArea;

	void Awake()
	{
		playArea = PlayArea.Get();
	}

	void Update()
	{
		if (!PhotonNetwork.isMasterClient) return;
		if (PhotonNetwork.room == null) return;
		PhotonNetwork.room.IsOpen = PhotonNetwork.room.PlayerCount == MaxNumberOfPlayers;
	}
	
	[PunRPC]
	// ReSharper disable once UnusedMember.Global
	public void AssignPlayer(PhotonMessageInfo info)
	{
		var index = info.sender.ID % MaxNumberOfPlayers;
		photonView.RPC("JoinGame", info.sender, index);
	}
	
	[PunRPC]
	// ReSharper disable once UnusedMember.Global
	public void JoinGame(int playerIndex)
	{
		PhotonNetwork.Instantiate(PlayerPrefabs[playerIndex].name, playArea.NextSpawnPoint(), Quaternion.identity, 0);
	}

	public static GameController Get()
	{
		return GameObject.FindGameObjectWithTag(typeof(GameController).Name).GetComponent<GameController>();
	}
}