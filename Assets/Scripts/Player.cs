using UnityEngine;

public class Player : Photon.MonoBehaviour, IPunObservable
{
    public delegate void PlayerAction(Player player);
    public static PlayerAction OnPlayerJoined;

    [HideInInspector] public GameColor Color;
    public float Speed;
    
    [HideInInspector] public bool IsLocal;
    
    void Awake()
    {
        IsLocal = photonView.isMine;

        Color = ColorManager.Get().GetRandomColor();
        
        if (OnPlayerJoined != null) OnPlayerJoined(this);
    }
    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(Color.Value.r);
            stream.SendNext(Color.Value.g);
            stream.SendNext(Color.Value.b);
        }
        else
        {
            Color.Value.r = (float) stream.ReceiveNext();
            Color.Value.g = (float) stream.ReceiveNext();
            Color.Value.b = (float) stream.ReceiveNext();
        }
    }
}