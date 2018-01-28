using UnityEngine;

public class Player : Photon.MonoBehaviour
{
    public float Speed;
    public Color Color;
    public int Contested;
    
    [HideInInspector] public bool IsLocal;
    
    void Awake()
    {
        IsLocal = photonView.isMine;
        if (IsLocal)
        {
            CameraController.Get().Target = transform;
            Score.Get().Player = this;
        }
    }
}