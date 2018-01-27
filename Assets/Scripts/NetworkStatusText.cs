using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class NetworkStatusText : Photon.MonoBehaviour
{
	public string Default;
	public string ConnectedToMaster;
	public string JoinedLobby;
	public string PhotonRandomJoinFailed;
	public string FailedToConnectToPhoton;
	public string JoinedRoom;
	
	Text status;
	
	void Awake()
	{
		status = GetComponent<Text>();
		status.text = Default;
	}
	
	// ReSharper disable once UnusedMember.Global
	public void OnConnectedToMaster()
	{
		Debug.Log("OnConnectedToMaster()");
		status.text = ConnectedToMaster;
	}
    
	// ReSharper disable once UnusedMember.Global
	public void OnJoinedLobby()
	{
		Debug.Log("OnJoinedLobby()");
		status.text = JoinedLobby;
	}
    
	// ReSharper disable once UnusedMember.Global
	public void OnPhotonRandomJoinFailed()
	{
		Debug.Log("OnPhotonRandomJoinFailed()");
		status.text = PhotonRandomJoinFailed;
	}
    
	// ReSharper disable once UnusedMember.Global
	public void OnFailedToConnectToPhoton(DisconnectCause cause)
	{
		Debug.LogError("Cause: " + cause);
		status.text = FailedToConnectToPhoton;
	}
    
	// ReSharper disable once UnusedMember.Global
	public void OnJoinedRoom()
	{
		Debug.Log("OnJoinedRoom()");
		status.text = JoinedRoom;
	}
}