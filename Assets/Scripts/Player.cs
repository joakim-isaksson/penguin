using UnityEngine;

public class Player : Photon.MonoBehaviour, IPunObservable
{
    public delegate void PlayerAction(Player player);
    public static PlayerAction OnPlayerJoined;

    public Color color;
    public float Speed;
    
    [HideInInspector] public bool IsLocal;
    
    void Awake()
    {
        IsLocal = photonView.isMine;
        
        if (IsLocal) color = new Color(Random.value, Random.value, Random.value);
        
        if (OnPlayerJoined != null) OnPlayerJoined(this);
    }
    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(color.r);
            stream.SendNext(color.g);
            stream.SendNext(color.b);
        }
        else
        {
            color.r = (float) stream.ReceiveNext();
            color.g = (float) stream.ReceiveNext();
            color.b = (float) stream.ReceiveNext();
        }
    }
}