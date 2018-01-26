using UnityEngine;

public class AutoJoinGame : Photon.MonoBehaviour
{
    public bool AutoConnect = true;
    public byte Version = 1;
    public byte MaxNumberOfPlayers = 12;
    
    bool connectInUpdate = true;

    GameController game;

    void Awake()
    {
        game = GameController.Get();
    }

    public void Start()
    {
        PhotonNetwork.autoJoinLobby = false;    // we join randomly. always. no need to join a lobby to get the list of rooms.
    }

    public void Update()
    {
        if (!connectInUpdate || !AutoConnect || PhotonNetwork.connected) return;
        
        Debug.Log("Update()");

        connectInUpdate = false;
        PhotonNetwork.ConnectUsingSettings(Version + "." + SceneManagerHelper.ActiveSceneBuildIndex);
    }

    // ReSharper disable once UnusedMember.Global
    public void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster()");
        PhotonNetwork.JoinRandomRoom();
    }
    
    // ReSharper disable once UnusedMember.Global
    public void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby()");
        PhotonNetwork.JoinRandomRoom();
    }
    
    // ReSharper disable once UnusedMember.Global
    public void OnPhotonRandomJoinFailed()
    {
        Debug.Log("OnPhotonRandomJoinFailed()");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxNumberOfPlayers }, null);
    }
    
    // ReSharper disable once UnusedMember.Global
    public void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        Debug.LogError("Cause: " + cause);
    }
    
    // ReSharper disable once UnusedMember.Global
    public void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom()");
        game.JoinGame();
    }
}
