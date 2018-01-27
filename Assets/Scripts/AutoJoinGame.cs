public class AutoJoinGame : Photon.MonoBehaviour
{
    public bool OfflineMode;
    public bool AutoConnect = true;
    public byte Version = 1;
    
    bool connectInUpdate = true;

    GameController game;

    void Awake()
    {
        game = GameController.Get();
        PhotonNetwork.offlineMode = OfflineMode;
    }

    public void Start()
    {
        PhotonNetwork.autoJoinLobby = false;    // we join randomly. always. no need to join a lobby to get the list of rooms.
    }

    public void Update()
    {
        if (!connectInUpdate || !AutoConnect || PhotonNetwork.connected) return;

        connectInUpdate = false;
        PhotonNetwork.ConnectUsingSettings(Version + "." + SceneManagerHelper.ActiveSceneBuildIndex);
    }

    // ReSharper disable once UnusedMember.Global
    public void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    
    // ReSharper disable once UnusedMember.Global
    public void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    
    // ReSharper disable once UnusedMember.Global
    public void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = game.MaxNumberOfPlayers }, null);
    }
    
    // ReSharper disable once UnusedMember.Global
    public void OnJoinedRoom()
    {
        game.JoinGame();
    }
}
