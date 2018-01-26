using UnityEngine;

public class Player : Photon.MonoBehaviour
{
    public delegate void PlayerAction(Player player);
    public static PlayerAction OnPlayerJoined;

    public float Speed;
    
    [HideInInspector] public bool IsLocal;
    
    void Awake()
    {
        IsLocal = photonView.isMine;
        if (OnPlayerJoined != null) OnPlayerJoined(this);
    }
}