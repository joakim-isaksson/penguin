using UnityEngine;

public class Player : Photon.MonoBehaviour
{
    public float Speed;
    public Color Color;
    
    [HideInInspector] public bool IsLocal;
    
    void Awake()
    {
        IsLocal = photonView.isMine;
        if (IsLocal) CameraController.Get().Target = transform;
    }
}